using Wms.Api.DataAccess;

namespace Wms.Api.Infrastructure;

public static class ServicesConfigurator
{
    private static IServiceCollection _services;
    private static AppConfiguration _config;

    public static void ConfigureServices(this WebApplicationBuilder builder) {
        InitializeServices(builder);
        ConfigureDatabase();
    }

    private static void InitializeServices(WebApplicationBuilder builder) {
        _services = builder.Services;
        _config = new AppConfiguration(builder.Configuration);
    }

    private static void ConfigureDatabase() {
        var connString = _config.ASPNETCORE_ENVIRONMENT == "Test"
            ? _config.DATABASE_URL_TEST
            : _config.DATABASE_URL;
        _services.AddDbContext<Db>(
            options => options
                .UseNpgsql(connString)
                .UseSnakeCaseNamingConvention(),
            contextLifetime: ServiceLifetime.Scoped,
            optionsLifetime: ServiceLifetime.Singleton);
        _services.AddDbContextFactory<Db>(
            options => options
                .UseNpgsql(connString)
                .UseSnakeCaseNamingConvention(),
            lifetime: ServiceLifetime.Singleton);
    }
}
