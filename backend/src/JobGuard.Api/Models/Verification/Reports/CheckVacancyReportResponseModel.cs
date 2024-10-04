namespace JobGuard.Api.Models.Verification.Reports;

internal record CheckVacancyReportResponseModel
{
    /// <summary>
    /// Shows general fraud risk. Less is better. Max value 100.
    /// Calculated based on all discovered red flags.
    /// </summary>
    public required int FraudRiskScore { get; init; }

    public required bool CompanyVerified { get; init; }

    /// <summary>
    /// Represents vacancy that was posted by the 
    /// </summary>
    public required VacancyDetailsViewModel VacancyDetails { get; init; }

    public required CompanyDetailsViewModel CompanyDetails { get; init; }

    public required List<RedFlagViewModel> RedFlags { get; init; }

    /// <summary>
    /// Verification date to use caching and avoid processing same vacations couple times.
    /// </summary>
    public required DateOnly VerificationDate { get; init; }
}