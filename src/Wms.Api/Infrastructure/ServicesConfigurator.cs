using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Wms.Api.Authorization;
using Wms.Api.DataAccess;
using Wms.Api.Repositories;

namespace Wms.Api.Infrastructure;

public static class ServicesConfigurator
{
    private static IServiceCollection _services;
    private static AppConfiguration _config;

    public static void ConfigureServices(this WebApplicationBuilder builder) {
        InitializeServices(builder);
        ConfigureDatabase();
        ConfigureConfiguration();
        ConfigureRepos();
        ConfigureAuthentication();
        ConfigureFastEndpoints();
    }

    private static void InitializeServices(WebApplicationBuilder builder) {
        _services = builder.Services;
        _config = new AppConfiguration(builder.Configuration);
    }

    private static void ConfigureRepos() {
        _services
            .AddTransient<AuthRepo>();
    }

    private static void ConfigureConfiguration() {
        _services.AddSingleton(_config);
    }

    private static void ConfigureAuthentication() {
        _services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        _services
            .AddAuthenticationCookie(validFor: TimeSpan.FromMinutes(10))
            .AddAuthorization(options => {
                options.AddPolicy(
                    Policies.WORKER_POLICY, 
                    policy => policy
                        .RequireAuthenticatedUser()
                        .RequireAssertion(context =>
                            context.User.Identities.Any(i => i.Claims.Any(c => c.Type == ClaimTypes.Role && Roles.ALL.Contains(c.Value)))));
                options.AddPolicy(
                    Policies.ADMIN_POLICY, 
                    policy => policy
                        .RequireAuthenticatedUser()
                        .RequireAssertion(context =>
                            context.User.Identities.Any(i => i.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == Roles.ADMIN))));
            });
    }

    private static void ConfigureFastEndpoints() {
        _services.AddFastEndpoints();
    }

    private static void ConfigureDatabase() {
        var connString = _config.ASPNETCORE_ENVIRONMENT == "Test"
            ? _config.DATABASE_URL_TEST
            : _config.DATABASE_URL;
        _services.AddDbContext<Db>(
            options => options
                .UseNpgsql(connString)
                .UseSnakeCaseNamingConvention(),
            contextLifetime: ServiceLifetime.Scoped);
    }
}
