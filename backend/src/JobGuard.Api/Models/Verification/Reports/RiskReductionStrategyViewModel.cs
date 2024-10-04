namespace JobGuard.Api.Models.Verification.Reports;

/// <summary>
/// Represents the strategy used to reduce the risk associated with a red flag.
/// </summary>
internal record RiskReductionStrategyViewModel(
    string StrategyType, string Description)
{
    /// <summary>
    /// The type of risk reduction strategy (e.g., manual review, verification via trusted sources).
    /// </summary>
    public string StrategyType { get; init; } = StrategyType;

    /// <summary>
    /// Description of how the risk is mitigated or reduced.
    /// </summary>
    public string Description { get; init; } = Description;
}