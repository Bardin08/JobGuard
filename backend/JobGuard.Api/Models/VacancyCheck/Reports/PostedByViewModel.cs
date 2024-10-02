namespace JobGuard.Api.Models.VacancyCheck.Reports;

/// <summary>
/// Represents the person who posted the vacancy.
/// Data Sources: Job Board Metadata.
/// </summary>
internal record PostedByViewModel(string? Name, string? Email, string? Phone)
{
    /// <summary>
    /// The name of the person who posted the job.
    /// Data Source: Job Board Metadata.
    /// </summary>
    public string? Name { get; init; } = Name;

    /// <summary>
    /// The email address of the person who posted the job.
    /// Data Source: Job Board Metadata.
    /// </summary>
    public string? Email { get; init; } = Email;

    /// <summary>
    /// The contact phone number of the person who posted the job.
    /// Data Source: Job Board Metadata.
    /// </summary>
    public string? Phone { get; init; } = Phone;
}