namespace JobGuard.Api.Models.VacancyCheck.Reports;

/// <summary>
/// Represents compensation details for the job.
/// Data Sources: Job boards, Company websites.
/// </summary>
internal record CompensationDetailsViewModel(
    string? SalaryRange,
    IEnumerable<string>? Benefits,
    string? BonusStructure,
    string? EquityOptions)
{
    /// <summary>
    /// The salary range offered for the job.
    /// Data Source: Job Boards, Company Website.
    /// </summary>
    public string? SalaryRange { get; init; } = SalaryRange;

    /// <summary>
    /// Benefits offered for the job.
    /// Data Source: Job Boards, Company Website.
    /// </summary>
    public IEnumerable<string>? Benefits { get; init; } = Benefits;

    /// <summary>
    /// The bonus structure, if any, offered for the job.
    /// Data Source: Company Website.
    /// </summary>
    public string? BonusStructure { get; init; } = BonusStructure;

    /// <summary>
    /// Equity options available for the job, if applicable.
    /// Data Source: Company Website.
    /// </summary>
    public string? EquityOptions { get; init; } = EquityOptions;
}