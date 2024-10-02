namespace JobGuard.Api.Models.VacancyCheck.Reports;

/// <summary>
/// Represents the details of the job vacancy.
/// Data Sources: LinkedIn, DOU.ua, Robota.ua.
/// </summary>
internal record VacancyDetailsViewModel(
    string JobTitle,
    string JobDescription,
    string JobLocation,
    string? SalaryRange,
    string? EmploymentType,
    string PostedDate,
    string? ApplicationDeadline,
    string CompanyName,
    IEnumerable<string>? SourcePlatforms)
{
    /// <summary>
    /// Title of the job vacancy.
    /// Data Source: Job Boards (LinkedIn, DOU.ua, Robota.ua).
    /// </summary>
    public string JobTitle { get; init; } = JobTitle;

    /// <summary>
    /// Description of the job, including key responsibilities.
    /// Data Source: Job Boards (LinkedIn, DOU.ua, Robota.ua).
    /// </summary>
    public string JobDescription { get; init; } = JobDescription;

    /// <summary>
    /// Location of the job, or "Remote" if applicable.
    /// Data Source: Job Boards (LinkedIn, DOU.ua, Robota.ua).
    /// </summary>
    public string JobLocation { get; init; } = JobLocation;

    /// <summary>
    /// The offered salary range, if provided.
    /// Data Source: Job Boards, Company Website.
    /// </summary>
    public string? SalaryRange { get; init; } = SalaryRange;

    /// <summary>
    /// Employment type (e.g., Full-time, Part-time).
    /// Data Source: Job Boards (LinkedIn, DOU.ua, Robota.ua).
    /// </summary>
    public string? EmploymentType { get; init; } = EmploymentType;

    /// <summary>
    /// The date the job was posted.
    /// Data Source: Job Boards (LinkedIn, DOU.ua, Robota.ua).
    /// </summary>
    public string PostedDate { get; init; } = PostedDate;

    /// <summary>
    /// Deadline for job applications, if specified.
    /// Data Source: Job Boards (LinkedIn, DOU.ua, Robota.ua).
    /// </summary>
    public string? ApplicationDeadline { get; init; } = ApplicationDeadline;

    /// <summary>
    /// Name of the company offering the job.
    /// Data Source: Job Boards (LinkedIn, DOU.ua, Robota.ua).
    /// </summary>
    public string CompanyName { get; init; } = CompanyName;

    /// <summary>
    /// Platforms where the job posting was found.
    /// Data Source: Job Boards (LinkedIn, DOU.ua, Robota.ua).
    /// </summary>
    public IEnumerable<string>? SourcePlatforms { get; init; } = SourcePlatforms;
}