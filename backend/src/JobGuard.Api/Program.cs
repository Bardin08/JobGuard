using JobGuard.Api.Endpoints;
using JobGuard.Api.Middlewares;
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

app.MapGet("/healthz", () => Results.Ok())
    .WithTags("HealthCheck")
    .WithOpenApi();

app.MapVerificationsEndpoints();

app.UseCors("allow-all");
app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

app.Run();