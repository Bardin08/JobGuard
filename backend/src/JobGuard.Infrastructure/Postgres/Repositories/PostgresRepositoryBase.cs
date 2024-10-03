namespace JobGuard.Infrastructure.Postgres.Repositories;

public abstract class PostgresRepositoryBase(PostgresAppDbContext dbContext)
{
    protected readonly PostgresAppDbContext DbContext = dbContext;
}