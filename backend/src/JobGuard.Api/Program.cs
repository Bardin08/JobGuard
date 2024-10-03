using JobGuard.Api.Extensions;
using JobGuard.Api.Middlewares;
using JobGuard.Api.Models.Mocks;
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

app.MapPost
    (
        "/vacancies/check", async (
            [FromBody] CheckVacancyRequestModel requestModel,
            [FromServices] ISender mediator
        ) =>
        {
            var createVerificationCommand = new CreateVerificationCommand(requestModel.DescriptionOrLink);
            
            var verificationId = await mediator.Send(createVerificationCommand);
            if (string.IsNullOrEmpty(verificationId))
            {
                return Results.BadRequest();
            }
            
            var executeVerificationCommand = new ExecuteVerificationCommand(verificationId);
            await mediator.Send(executeVerificationCommand);

            return Results.Ok(verificationId);
        })
    .WithTags("Vacancies")
    .WithOpenApi();

app.MapGet
    (
        "vacancies/result",
        (HttpRequest httpReq, [FromQuery] string checkId)
            => Results.Ok(new CheckVacancyResultResponseModel
            (
                // fetch real values from the check results
                VacancyReal: true,
                CompanyReal: true,
                DetailedReportUrl: $"{httpReq.GetBaseUrl()}/vacancies/report?checkId=" + checkId
            ))
    )
    .WithTags("Vacancies")
    .WithOpenApi();

app.MapGet("vacancies/report", ([FromQuery] string checkId) =>
    {
        var reportMockModel = Random.Shared.Next(0, 10) < 5
            ? CheckVacancyReportResponseModelMock.BadVacancy
            : CheckVacancyReportResponseModelMock.GoodVacancy;

        return Results.Ok(reportMockModel);
    })
    .WithTags("Vacancies")
    .WithOpenApi();

app.UseCors("allow-all");
app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

app.Run();

internal record CheckVacancyRequestModel
{
    public required string DescriptionOrLink { get; init; }
}

internal record CheckVacancyResponseModel(string CheckId);

internal record CheckVacancyResultResponseModel(bool VacancyReal, bool CompanyReal, string DetailedReportUrl);