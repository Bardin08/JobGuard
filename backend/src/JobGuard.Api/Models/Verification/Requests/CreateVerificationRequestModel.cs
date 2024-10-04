namespace JobGuard.Api.Models.Verification.Requests;

internal record CreateVerificationRequestModel
{
    public required string DescriptionOrLink { get; init; }
}