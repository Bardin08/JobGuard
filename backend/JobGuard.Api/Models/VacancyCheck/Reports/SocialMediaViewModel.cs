namespace JobGuard.Api.Models.VacancyCheck.Reports;

/// <summary>
/// Represents the social media profiles of the company.
/// Data Sources: LinkedIn, Facebook.
/// </summary>
internal record SocialMediaViewModel(string? LinkedIn, string? Facebook)
{
    /// <summary>
    /// The LinkedIn profile of the company.
    /// Data Source: LinkedIn.
    /// </summary>
    public string? LinkedIn { get; init; } = LinkedIn;

    /// <summary>
    /// The Facebook profile of the company.
    /// Data Source: Facebook.
    /// </summary>
    public string? Facebook { get; init; } = Facebook;
}