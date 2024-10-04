using Jobby.Domain.Repositories;

namespace JobGuard.Infrastructure.Postgres;

internal sealed class UnitOfWork(PostgresAppDbContext dbContext) : IUnitOfWork
{
    private readonly PostgresAppDbContext _dbContext = dbContext;

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
