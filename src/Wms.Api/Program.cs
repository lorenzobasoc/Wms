using Wms.Api.DataAccess;
using Wms.Api.Infrastructure;

namespace Wms.Api;

public class Program
{
    public static async Task Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        builder.ConfigureServices();
        var app = builder.Build();
        app.ConfigurePipeline();
        await MigrateDb(app);
        await app.RunAsync();
    }

    private static async Task MigrateDb(WebApplication app) {
        using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var db = serviceScope.ServiceProvider.GetService<Db>() ?? throw new NullReferenceException();
        await db.Database.MigrateAsync();
    }
}
