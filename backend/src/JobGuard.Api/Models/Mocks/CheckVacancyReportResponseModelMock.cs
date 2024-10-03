using JobGuard.Api.Models.VacancyCheck.Reports;

namespace JobGuard.Api.Models.Mocks;

internal static class CheckVacancyReportResponseModelMock
{
    public static CheckVacancyReportResponseModel GoodVacancy =>
        new()
        {
            FraudRiskScore = 10,
            CompanyVerified = true,
            VacancyDetails = new VacancyDetailsViewModel(
                JobTitle: "Software Engineer",
                JobDescription: "We are looking for a Software Engineer with experience in .NET.",
                JobLocation: "Kyiv, Ukraine",
                SalaryRange: "$3000 - $4000",
                EmploymentType: "Full-time",
                PostedDate: new DateTimeOffset(new DateOnly(2024, 1, 1), new TimeOnly(0), new TimeSpan(0)),
                ApplicationDeadline: new DateTimeOffset(new DateOnly(2024, 1, 30), new TimeOnly(0), new TimeSpan(0)),
                CompanyName: "Tech Company",
                DataSources: new List<string> { "LinkedIn", "DOU.ua" },
                Metadata: new TechnicalDataViewModel(
                    PostedBy: new PostedByViewModel("John Doe", "john@example.com", "+380123456789"),
                    PostingType: "Manual",
                    LastUpdated: DateTimeOffset.Now
                )
            ),
            CompanyDetails = new CompanyDetailsViewModel(
                Name: "Tech Company",
                Industry: "IT",
                CompanySize: "500-1000",
                CompanyDescription: "An innovative tech company.",
                CompanyWebsite: "https://techcompany.com",
                LegalDetails: new CompanyLegalDetailsViewModel("123456789", "2020-01-01", "Kyiv, Ukraine"),
                SocialMediaLinks: new List<string> { "https://linkedin.com/company/techcompany" },
                FinancialData: new FinancialDataViewModel("10M", true),
                ComplianceStatus: new ComplianceStatusViewModel(null, null, null),
                EmployeeReviewRating: 4.5,
                EmployeeReviews: new List<EmployeeReviewViewModel>
                {
                    new("Glassdoor", 4.5, "Great company to work for.")
                },
                DataSources: new List<string> { "LinkedIn", "YouScore" }
            ),
            RedFlags = new List<RedFlagViewModel>(),
            VerificationDate = new DateOnly(2024, 1, 1)
        };

    public static CheckVacancyReportResponseModel BadVacancy =>
        new()
        {
            FraudRiskScore = 90,
            CompanyVerified = false,
            VacancyDetails = new VacancyDetailsViewModel(
                JobTitle: "Senior Software Developer",
                JobDescription: "Job description looks suspicious.",
                JobLocation: "Unknown",
                SalaryRange: null,
                EmploymentType: null,
                PostedDate: new DateTimeOffset(new DateOnly(2024, 1, 5), new TimeOnly(0), new TimeSpan(0)),
                ApplicationDeadline: null,
                CompanyName: "Suspicious Corp",
                DataSources: new List<string> { "Unknown" },
                Metadata: new TechnicalDataViewModel(
                    PostedBy: null,
                    PostingType: "Automated",
                    LastUpdated: DateTimeOffset.Now
                )
            ),
            CompanyDetails = new CompanyDetailsViewModel(
                Name: "Suspicious Corp",
                Industry: "Unknown",
                CompanySize: null,
                CompanyDescription: "No details available.",
                CompanyWebsite: null,
                LegalDetails: new CompanyLegalDetailsViewModel(null, null, null),
                SocialMediaLinks: new List<string>(),
                FinancialData: null,
                ComplianceStatus: new ComplianceStatusViewModel("Multiple issues", "Litigation history found",
                    "Sanctions found"),
                EmployeeReviewRating: null,
                EmployeeReviews: null,
                DataSources: new List<string> { "Unknown" }
            ),
            RedFlags = new List<RedFlagViewModel>
            {
                new(
                    "Suspicious Job Posting",
                    "Job details are unclear",
                    "The job description lacks clarity, and no salary range is provided.",
                    SeverityLevel.Critical,
                    new RiskReductionStrategyViewModel("Manual Review",
                        "Verify the company credentials through trusted sources.")
                )
            },
            VerificationDate = new DateOnly(2024, 1, 5)
        };
}