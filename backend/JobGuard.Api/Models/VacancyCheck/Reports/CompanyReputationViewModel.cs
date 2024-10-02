namespace JobGuard.Api.Models.VacancyCheck.Reports;

/// <summary>
/// Represents the company's reputation based on employee reviews and other public feedback.
/// Data Sources: Glassdoor, Indeed, DOU.ua.
/// </summary>
internal record CompanyReputationViewModel(
    IEnumerable<EmployeeReviewViewModel>? EmployeeReviews,
    IEnumerable<string>? PublicFlags)
{
    /// <summary>
    /// Employee reviews for the company.
    /// Data Source: Glassdoor, DOU.ua.
    /// </summary>
    public IEnumerable<EmployeeReviewViewModel>? EmployeeReviews { get; init; } = EmployeeReviews;

    /// <summary>
    /// Public flags such as compliance issues or fraud reports.
    /// Data Source: DOU.ua, Forums.
    /// </summary>
    public IEnumerable<string>? PublicFlags { get; init; } = PublicFlags;
}