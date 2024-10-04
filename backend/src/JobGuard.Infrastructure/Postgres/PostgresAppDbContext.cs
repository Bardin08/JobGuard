using Microsoft.EntityFrameworkCore;

namespace JobGuard.Infrastructure.Postgres;

public class PostgresAppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresAppDbContext).Assembly);
}