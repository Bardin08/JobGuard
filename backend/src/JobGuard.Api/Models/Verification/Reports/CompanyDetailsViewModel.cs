namespace JobGuard.Api.Models.Verification.Reports;

/// <summary>
/// Represents information about the company offering the job.
/// Data Sources: Business registries, LinkedIn, YouScore, Glassdoor.
/// </summary>
internal record CompanyDetailsViewModel(
    string Name,
    string Industry,
    string? CompanySize,
    string? CompanyDescription,
    string? CompanyWebsite,
    CompanyLegalDetailsViewModel? LegalDetails,
    List<string> SocialMediaLinks,
    FinancialDataViewModel? FinancialData,
    ComplianceStatusViewModel? ComplianceStatus,
    double? EmployeeReviewRating,
    IEnumerable<EmployeeReviewViewModel>? EmployeeReviews,
    List<string> DataSources)
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
    /// The official website of the company.
    /// Data Source: LinkedIn, Company Website.
    /// </summary>
    public string? CompanyWebsite { get; init; } = CompanyWebsite;

    /// <summary>
    /// A description of the company and its business activities.
    /// Data Source: LinkedIn, Company Website.
    /// </summary>
    public string? CompanyDescription { get; init; } = CompanyDescription;

    public CompanyLegalDetailsViewModel? LegalDetails { get; set; } = LegalDetails;
    
    /// <summary>
    /// Social media profiles of the company.
    /// Data Source: LinkedIn, Facebook.
    /// </summary>
    public List<string> SocialMediaLinks { get; init; } = SocialMediaLinks;

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
    /// Data Source: Glassdoor, DOU.ua. The maximum value is 5.
    /// </summary>
    public double? EmployeeReviewRating { get; init; } = EmployeeReviewRating;

    /// <summary>
    /// Reviews and feedback from employees about the company.
    /// Data Source: Glassdoor, DOU.ua.
    /// </summary>
    public IEnumerable<EmployeeReviewViewModel>? EmployeeReviews { get; init; } = EmployeeReviews;

    /// <summary>
    /// Source where the company information was retrieved.
    /// Data Source: LinkedIn, YouScore, Business Registries.
    /// </summary>
    public List<string> DataSources { get; init; } = DataSources;
}