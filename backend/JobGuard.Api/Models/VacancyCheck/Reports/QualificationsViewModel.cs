namespace JobGuard.Api.Models.VacancyCheck.Reports;

/// <summary>
/// Represents the required qualifications for the job vacancy.
/// Data Sources: Job boards such as LinkedIn, DOU.ua, Robota.ua.
/// </summary>
internal record QualificationsViewModel(
    IEnumerable<string>? EducationRequirements,
    IEnumerable<string>? ExperienceRequirements,
    IEnumerable<string>? Skills,
    IEnumerable<string>? Certifications)
{
    /// <summary>
    /// The educational qualifications required for the job.
    /// Data Source: Job Boards (LinkedIn, DOU.ua, Robota.ua).
    /// </summary>
    public IEnumerable<string>? EducationRequirements { get; init; } = EducationRequirements;

    /// <summary>
    /// Experience required for the job.
    /// Data Source: Job Boards (LinkedIn, DOU.ua, Robota.ua).
    /// </summary>
    public IEnumerable<string>? ExperienceRequirements { get; init; } = ExperienceRequirements;

    /// <summary>
    /// Skills required for the job.
    /// Data Source: Job Boards (LinkedIn, DOU.ua, Robota.ua).
    /// </summary>
    public IEnumerable<string>? Skills { get; init; } = Skills;

    /// <summary>
    /// Certifications required for the job, if any.
    /// Data Source: Job Boards (LinkedIn, DOU.ua, Robota.ua).
    /// </summary>
    public IEnumerable<string>? Certifications { get; init; } = Certifications;
}