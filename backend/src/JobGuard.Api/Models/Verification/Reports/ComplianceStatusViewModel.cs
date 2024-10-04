namespace JobGuard.Api.Models.Verification.Reports;

/// <summary>
/// Represents the compliance status of the company, including legal and regulatory information.
/// Data Sources: YouScore, Business Registries.
/// </summary>
internal record ComplianceStatusViewModel(
    string? ComplianceIssues,
    string? LitigationHistory,
    string? SanctionsCheck)
{
    /// <summary>
    /// Any compliance issues flagged.
    /// Data Source: YouScore.
    /// </summary>
    public string? ComplianceIssues { get; init; } = ComplianceIssues;

    /// <summary>
    /// The litigation history of the company.
    /// Data Source: Public Records.
    /// </summary>
    public string? LitigationHistory { get; init; } = LitigationHistory;

    /// <summary>
    /// Sanctions check status of the company.
    /// Data Source: YouScore.
    /// </summary>
    public string? SanctionsCheck { get; init; } = SanctionsCheck;
}