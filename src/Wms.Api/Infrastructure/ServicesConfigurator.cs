using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Wms.Api.Constants.Authorization;
using Wms.Api.DataAccess;
using Wms.Api.Repositories;
using Wms.Api.Services;

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
        ConfigureBookingValidation();
    }

    private static void InitializeServices(WebApplicationBuilder builder) {
        _services = builder.Services;
        _config = new AppConfiguration(builder.Configuration);
    }

    private static void ConfigureBookingValidation() {
        _services.AddScoped<BookingValidationService>();
    }

    private static void ConfigureRepos() {
        _services
            .AddTransient<FloorRepo>()
            .AddTransient<RoomRepo>()
            .AddTransient<SeatRepo>()
            .AddTransient<TableRepo>()
            .AddTransient<BookingRepo>()
            .AddTransient<InvitationRepo>()
            .AddTransient<UserRepo>();
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
                    AppPolicies.WORKER_POLICY, 
                    policy => policy
                        .RequireAuthenticatedUser()
                        .RequireAssertion(context =>
                            context.User.Identities.Any(i => i.Claims.Any(c => c.Type == ClaimTypes.Role && Roles.ALL.Contains(c.Value)))));
                options.AddPolicy(
                    AppPolicies.ADMIN_POLICY, 
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
