namespace Wms.Api.Infrastructure;

public static class PipelineConfigurator
{
    public static void ConfigurePipeline(this WebApplication app) {
        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
    }
}
