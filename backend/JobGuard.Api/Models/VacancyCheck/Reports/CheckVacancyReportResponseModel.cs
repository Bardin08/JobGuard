namespace JobGuard.Api.Models.VacancyCheck.Reports;

/// <summary>
/// Represents the response model for checking a vacancy report, 
/// which includes vacancy details, company information, qualifications, 
/// and verification status.
/// </summary>
internal record CheckVacancyReportResponseModel(
    VacancyDetailsViewModel VacancyDetailsViewModel,
    CompanyInfoViewModel CompanyInfoViewModel,
    QualificationsViewModel? Qualifications,
    CompensationDetailsViewModel? CompensationDetails,
    CompanyReputationViewModel? CompanyReputation,
    VacancyVerificationViewModel VacancyVerificationViewModel,
    TechnicalDataViewModel? TechnicalData)
{
    /// <summary>
    /// Vacancy details, including title, description, location, and other key information.
    /// Data Sources: LinkedIn, DOU.ua, Robota.ua.
    /// </summary>
    public VacancyDetailsViewModel VacancyDetailsViewModel { get; init; } = VacancyDetailsViewModel;

    /// <summary>
    /// Company information including name, size, industry, and more.
    /// Data Sources: LinkedIn, YouScore, Company Website, Glassdoor.
    /// </summary>
    public CompanyInfoViewModel CompanyInfoViewModel { get; init; } = CompanyInfoViewModel;

    /// <summary>
    /// Qualifications required for the job, such as skills, certifications, and experience.
    /// Data Sources: LinkedIn, DOU.ua, Robota.ua.
    /// </summary>
    public QualificationsViewModel? Qualifications { get; init; } = Qualifications;

    /// <summary>
    /// Compensation details like salary, benefits, and equity.
    /// Data Sources: Job Boards, Company Website.
    /// </summary>
    public CompensationDetailsViewModel? CompensationDetails { get; init; } = CompensationDetails;

    /// <summary>
    /// Company reputation based on reviews and public feedback.
    /// Data Sources: Glassdoor, DOU.ua, Indeed.
    /// </summary>
    public CompanyReputationViewModel? CompanyReputation { get; init; } = CompanyReputation;

    /// <summary>
    /// Verification status of the job vacancy.
    /// Data Sources: JobGuard, LinkedIn, Robota.ua.
    /// </summary>
    public VacancyVerificationViewModel VacancyVerificationViewModel { get; init; } = VacancyVerificationViewModel;

    /// <summary>
    /// Technical data about the vacancy posting.
    /// Data Sources: Job Board Metadata.
    /// </summary>
    public TechnicalDataViewModel? TechnicalData { get; init; } = TechnicalData;
}