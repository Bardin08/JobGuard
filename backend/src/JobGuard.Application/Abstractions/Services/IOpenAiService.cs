using JobGuard.Application.Models.Vacancies;

namespace JobGuard.Application.Abstractions.Services;

public interface IOpenAiService
{
    Task<VacancyDto> GetVacancyFromDescription(string description, CancellationToken cancellationToken);
}
