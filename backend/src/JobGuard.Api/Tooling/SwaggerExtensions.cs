namespace JobGuard.Api.Tooling;

internal static class SwaggerExtensions
{
    public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        var enableSwagger = configuration.GetValue<bool>("Tooling:Swagger:Enabled");
        if (enableSwagger)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }

    public static void UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
    {
        var enableSwagger = configuration.GetValue<bool>("Tooling:Swagger:Enabled");
        if (enableSwagger)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}