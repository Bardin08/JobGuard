using JobGuard.Domain.Entities;

namespace JobGuard.Domain.Repositories;

public interface IVacancyRepository
{
    void Create(VacancyDetails vacancyDetails);
}