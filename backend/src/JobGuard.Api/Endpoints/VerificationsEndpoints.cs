using JobGuard.Api.Extensions;
using JobGuard.Api.Models.Verification.Mocks;
using JobGuard.Api.Models.Verification.Requests;
using JobGuard.Api.Models.Verification.Responses;
using JobGuard.Application.Verifications.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobGuard.Api.Endpoints;

public static class VerificationsEndpoints
{
    public static void MapVerificationsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var verificationsEndpoints = endpoints.MapGroup("verifications")
            .WithTags("Verifications")
            .WithOpenApi();

        verificationsEndpoints.MapPost("create", async (
                [FromBody] CreateVerificationRequestModel requestModel,
                [FromServices] ISender mediator) =>
            {
                var createVerificationCommand = new CreateVerificationCommand(requestModel.DescriptionOrLink);

                var verificationId = await mediator.Send(createVerificationCommand);
                if (string.IsNullOrEmpty(verificationId))
                    return Results.BadRequest();

                return Results.Created($"/verifications/{verificationId}", verificationId);
            }
        );

        verificationsEndpoints.MapPost("execute/{vId}", (
                [FromRoute] string vId,
                [FromServices] ISender mediator
            ) =>
            {
                // TODO: Not working because of DI scopes. Should be implemented with background processing.
                // Will implement in the next PR
                var executeVerificationCommand = new ExecuteVerificationCommand(vId);
                mediator.Send(executeVerificationCommand);
                return Results.Ok();
            }
        );

        verificationsEndpoints.MapGet("mocks/result/{vId}",
            (
                HttpRequest httpRequest,
                [FromRoute] string vId,
                [FromServices] IMediator mediator) =>
            {
                return Results.Ok(new VerificationResultResponseModel
                (
                    // fetch real values from the check results
                    VacancyReal: true,
                    CompanyReal: true,
                    DetailedReportUrl: $"{httpRequest.GetBaseUrl()}/vacancies/report?checkId=" + vId
                ));
            }
        );

        verificationsEndpoints.MapGet("mocks/report/{vId}",
            (
                [FromRoute] string vId) =>
            {
                var reportMockModel = Random.Shared.Next(0, 10) < 5
                    ? CheckVacancyReportResponseModelMock.BadVacancy
                    : CheckVacancyReportResponseModelMock.GoodVacancy;

                return Results.Ok(reportMockModel);
            }
        );
    }
}