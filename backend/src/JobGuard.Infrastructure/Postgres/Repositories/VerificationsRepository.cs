using JobGuard.Domain.Entities;
using JobGuard.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobGuard.Infrastructure.Postgres.Repositories;

public class VerificationsRepository(PostgresAppDbContext dbContext)
    : PostgresRepositoryBase(dbContext), IVerificationRepository
{
    public void Create(Verification verification)
        => DbContext.Set<Verification>().Add(verification);

    public void Update(Verification verification)
        => DbContext.Set<Verification>().Update(verification);

    public Task<Verification?> GetByShortId(string verificationId)
        => DbContext.Set<Verification>().FirstOrDefaultAsync(x => x.ShortId == verificationId);

    public Task<Verification?> GetById(Guid verificationId)
        => DbContext.Set<Verification>().FirstOrDefaultAsync(x => x.Id == verificationId);
}