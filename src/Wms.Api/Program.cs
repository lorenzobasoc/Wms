using Wms.Api.Infrastructure;

namespace Wms.Api;

public class Program
{
    public static async Task Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        builder.ConfigureServices();
        var app = builder.Build();
        app.ConfigurePipeline();
        await app.RunAsync();
    }
}
