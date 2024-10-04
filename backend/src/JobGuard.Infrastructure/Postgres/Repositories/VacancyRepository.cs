using JobGuard.Domain.Entities;
using JobGuard.Domain.Repositories;

namespace JobGuard.Infrastructure.Postgres.Repositories;

public class VacancyRepository(PostgresAppDbContext dbContext)
    : PostgresRepositoryBase(dbContext), IVacancyRepository
{
    public void Create(VacancyDetails vacancyDetails)
        => DbContext.Set<VacancyDetails>().Add(vacancyDetails);
}