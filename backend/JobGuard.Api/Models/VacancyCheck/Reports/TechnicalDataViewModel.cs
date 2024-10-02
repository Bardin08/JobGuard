namespace JobGuard.Api.Models.VacancyCheck.Reports;

/// <summary>
/// Represents technical details about the vacancy posting.
/// Data Sources: Job Board Metadata.
/// </summary>
internal record TechnicalDataViewModel(
    PostedByViewModel? PostedBy,
    string? PostingType,
    DateTimeOffset? LastUpdated)
{
    /// <summary>
    /// The individual who posted the job.
    /// Data Source: Job Board Metadata.
    /// </summary>
    public PostedByViewModel? PostedBy { get; init; } = PostedBy;

    /// <summary>
    /// The type of posting (e.g., Manual, Automated).
    /// Data Source: Job Board Metadata.
    /// </summary>
    public string? PostingType { get; init; } = PostingType;

    /// <summary>
    /// The date the job posting was last updated.
    /// Data Source: Job Board Metadata.
    /// </summary>
    public DateTimeOffset? LastUpdated { get; init; } = LastUpdated;
}