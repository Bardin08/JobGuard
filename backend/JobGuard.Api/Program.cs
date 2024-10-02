using JobGuard.Api.Extensions;
using JobGuard.Api.Models.Mocks;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
        "/vacancies/check",
        ([FromBody] CheckVacancyRequestModel requestModel)
            => Results.Ok(new CheckVacancyResponseModel(Guid.NewGuid().ToString()[..6]))
    )
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

app.Run();

internal record CheckVacancyRequestModel
{
    public required string DescriptionOrLink { get; init; }
}

internal record CheckVacancyResponseModel(string CheckId);

internal record CheckVacancyResultResponseModel(bool VacancyReal, bool CompanyReal, string DetailedReportUrl);