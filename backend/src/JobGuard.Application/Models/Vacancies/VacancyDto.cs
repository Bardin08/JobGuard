namespace JobGuard.Application.Models.Vacancies;

public record VacancyDto
{
    public required string JobTitle { get; init; }
    public string? JobLocation { get; init; }
    public string? SalaryRange { get; init; }
    public string? EmploymentType { get; init; }
    public required string JobDescription { get; init; }
    public DateTimeOffset? PostedDate { get; init; }
    public DateTimeOffset? ApplicationDeadline { get; init; }
    public required List<string> Responsibilities { get; init; }
    public required List<string> Qualifications { get; init; }
}