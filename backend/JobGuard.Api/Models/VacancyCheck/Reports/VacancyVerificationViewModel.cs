namespace JobGuard.Api.Models.VacancyCheck.Reports;

/// <summary>
/// Represents the verification status of the job vacancy.
/// Data Sources: JobGuard, cross-checking platforms like LinkedIn, Robota.ua.
/// </summary>
internal record VacancyVerificationViewModel(
    bool Verified,
    int? FraudScore,
    string? VerifiedBy,
    DateOnly VerificationDate,
    IEnumerable<string>? CrossCheckedPlatforms,
    IEnumerable<RedFlagViewModel>? RedFlags)
{
    /// <summary>
    /// Indicates if the vacancy has been verified.
    /// Data Source: JobGuard.
    /// </summary>
    public bool Verified { get; init; } = Verified;

    /// <summary>
    /// The date the vacancy was verified.
    /// Data Source: JobGuard.
    /// </summary>
    public DateOnly VerificationDate { get; init; } = VerificationDate;

    /// <summary>
    /// The entity that verified the vacancy.
    /// Data Source: JobGuard.
    /// </summary>
    public string? VerifiedBy { get; init; } = VerifiedBy;

    /// <summary>
    /// The fraud score for the vacancy.
    /// Data Source: JobGuard.
    /// </summary>
    public int? FraudScore { get; init; } = FraudScore;

    /// <summary>
    /// Platforms where the vacancy was cross-checked.
    /// Data Source: LinkedIn, Robota.ua.
    /// </summary>
    public IEnumerable<string>? CrossCheckedPlatforms { get; init; } = CrossCheckedPlatforms;

    /// <summary>
    /// Red flags identified during the verification process.
    /// Data Source: DOU.ua forums, Scam Reports.
    /// </summary>
    public IEnumerable<RedFlagViewModel>? RedFlags { get; init; } = RedFlags;
}