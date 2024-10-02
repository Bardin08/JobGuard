namespace JobGuard.Api.Models.VacancyCheck.Reports;

/// <summary>
/// Represents information about the company offering the job.
/// Data Sources: Business registries, LinkedIn, YouScore, Glassdoor.
/// </summary>
internal record CompanyInfoViewModel(
    string Name,
    string Industry,
    string? CompanySize,
    string? CompanyDescription,
    string? CompanyWebsite,
    string? RegistrationNumber,
    string? IncorporationDate,
    string? RegisteredAddress,
    SocialMediaViewModel? SocialMedia,
    FinancialDataViewModel? FinancialData,
    ComplianceStatusViewModel? ComplianceStatus,
    double? Rating,
    IEnumerable<string>? Reviews,
    string? Source)
{
    /// <summary>
    /// The legal name of the company.
    /// Data Source: LinkedIn, YouScore, Business Registries.
    /// </summary>
    public string Name { get; init; } = Name;

    /// <summary>
    /// The industry the company operates in.
    /// Data Source: LinkedIn, Company Website.
    /// </summary>
    public string Industry { get; init; } = Industry;

    /// <summary>
    /// The size of the company (number of employees).
    /// Data Source: LinkedIn.
    /// </summary>
    public string? CompanySize { get; init; } = CompanySize;

    /// <summary>
    /// A description of the company and its business activities.
    /// Data Source: LinkedIn, Company Website.
    /// </summary>
    public string? CompanyDescription { get; init; } = CompanyDescription;

    /// <summary>
    /// The official website of the company.
    /// Data Source: LinkedIn, Company Website.
    /// </summary>
    public string? CompanyWebsite { get; init; } = CompanyWebsite;

    /// <summary>
    /// The company's registration number.
    /// Data Source: Business Registries, YouScore.
    /// </summary>
    public string? RegistrationNumber { get; init; } = RegistrationNumber;

    /// <summary>
    /// The date the company was incorporated.
    /// Data Source: Business Registries, YouScore.
    /// </summary>
    public string? IncorporationDate { get; init; } = IncorporationDate;

    /// <summary>
    /// The registered address of the company.
    /// Data Source: Business Registries, YouScore.
    /// </summary>
    public string? RegisteredAddress { get; init; } = RegisteredAddress;

    /// <summary>
    /// Social media profiles of the company.
    /// Data Source: LinkedIn, Facebook.
    /// </summary>
    public SocialMediaViewModel? SocialMedia { get; init; } = SocialMedia;

    /// <summary>
    /// Financial information about the company, such as revenue and profitability.
    /// Data Source: YouScore, Business Registries.
    /// </summary>
    public FinancialDataViewModel? FinancialData { get; init; } = FinancialData;

    /// <summary>
    /// The company's compliance status, including legal and regulatory issues.
    /// Data Source: YouScore, Business Registries.
    /// </summary>
    public ComplianceStatusViewModel? ComplianceStatus { get; init; } = ComplianceStatus;

    /// <summary>
    /// The company's overall rating based on employee reviews.
    /// Data Source: Glassdoor, DOU.ua.
    /// </summary>
    public double? Rating { get; init; } = Rating;

    /// <summary>
    /// Reviews and feedback from employees about the company.
    /// Data Source: Glassdoor, DOU.ua.
    /// </summary>
    public IEnumerable<string>? Reviews { get; init; } = Reviews;

    /// <summary>
    /// Source where the company information was retrieved.
    /// Data Source: LinkedIn, YouScore, Business Registries.
    /// </summary>
    public string? Source { get; init; } = Source;
}