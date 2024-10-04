namespace JobGuard.Api.Models.Verification.Reports;

/// <summary>
/// Represents a red flag indicating potential issues in the job vacancy or company.
/// </summary>
internal record RedFlagViewModel(
    string Name,
    string ShortDescription,
    string LongDescription,
    SeverityLevel Severity,
    RiskReductionStrategyViewModel RiskReductionStrategy)
{
    /// <summary>
    /// The name of the red flag.
    /// </summary>
    public string Name { get; init; } = Name;

    /// <summary>
    /// A short description of the red flag.
    /// </summary>
    public string ShortDescription { get; init; } = ShortDescription;

    /// <summary>
    /// A detailed description of the red flag, explaining the issue in depth.
    /// </summary>
    public string LongDescription { get; init; } = LongDescription;

    /// <summary>
    /// The severity level of the red flag (Low, Medium, High, Critical).
    /// </summary>
    public SeverityLevel Severity { get; init; } = Severity;

    /// <summary>
    /// The strategy used to reduce the risk or protect against the red flag.
    /// </summary>
    public RiskReductionStrategyViewModel RiskReductionStrategy { get; init; } = RiskReductionStrategy;
}