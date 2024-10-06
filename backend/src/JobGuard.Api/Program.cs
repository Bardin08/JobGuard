using System.Text.Json;
using JobGuard.Api.Endpoints;
using JobGuard.Api.Middlewares;
using JobGuard.Api.Models;
using JobGuard.Api.Tooling;
using JobGuard.Application;
using JobGuard.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddSwagger(builder.Configuration);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("allow-all", cp => cp
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

app.UseSwagger(builder.Configuration);

app.MapGet("/healthz", () =>
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "build-metadata.json");

        if (File.Exists(filePath))
        {
            var metadata = File.ReadAllText(filePath);
            return Results.Ok(new
            {
                Status = "Healthy",
                BuildMetadata = JsonSerializer.Deserialize<BuildInfoResponseModel>(metadata)
            });
        }

        return Results.NotFound("Build metadata not found.");
    })
    .WithTags("HealthCheck")
    .WithOpenApi();

app.MapVerificationsEndpoints();

app.UseCors("allow-all");
app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

app.Run();