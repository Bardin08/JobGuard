using JobGuard.Api.Endpoints;
using JobGuard.Api.Extensions;
using JobGuard.Api.Middlewares;
using JobGuard.Application;
using JobGuard.Application.Verifications.Commands;
using JobGuard.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("allow-all", cp => cp
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/healthz", () => Results.Ok())
    .WithTags("HealthCheck")
    .WithOpenApi();

app.MapVerificationsEndpoints();

app.UseCors("allow-all");
app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

app.Run();