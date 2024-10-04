namespace JobGuard.Api.Models.Verification.Responses;

internal record VerificationResultResponseModel(bool VacancyReal, bool CompanyReal, string DetailedReportUrl);