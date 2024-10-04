namespace JobGuard.Api.Models.Verification.Reports;

internal record CompanyLegalDetailsViewModel(
    string? RegistrationNumber,
    string? IncorporationDate,
    string? RegisteredAddress)
{
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
}