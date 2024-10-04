namespace JobGuard.Api.Models.Verification.Reports;

/// <summary>
/// Represents financial information about the company.
/// Data Sources: Business registries, YouScore.
/// </summary>
internal record FinancialDataViewModel(string? AnnualRevenue, bool? Profitability)
{
    /// <summary>
    /// The company's annual revenue.
    /// Data Source: Business Registries, YouScore.
    /// </summary>
    public string? AnnualRevenue { get; init; } = AnnualRevenue;

    /// <summary>
    /// Indicates whether the company is profitable.
    /// Data Source: Business Registries, YouScore.
    /// </summary>
    public bool? Profitability { get; init; } = Profitability;
}