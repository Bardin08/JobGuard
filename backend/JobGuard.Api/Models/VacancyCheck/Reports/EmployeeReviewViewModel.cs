namespace JobGuard.Api.Models.VacancyCheck.Reports;

/// <summary>
/// Represents a single employee review.
/// Data Sources: Glassdoor, DOU.ua.
/// </summary>
internal record EmployeeReviewViewModel(
    string ReviewSource,
    double Rating,
    IEnumerable<string> Reviews)
{
    /// <summary>
    /// The platform where the review was found.
    /// Data Source: Glassdoor, DOU.ua.
    /// </summary>
    public string ReviewSource { get; init; } = ReviewSource;

    /// <summary>
    /// The rating provided by the employee.
    /// Data Source: Glassdoor, DOU.ua.
    /// </summary>
    public double Rating { get; init; } = Rating;

    /// <summary>
    /// The text of the employee review.
    /// Data Source: Glassdoor, DOU.ua.
    /// </summary>
    public IEnumerable<string> Reviews { get; init; } = Reviews;
}