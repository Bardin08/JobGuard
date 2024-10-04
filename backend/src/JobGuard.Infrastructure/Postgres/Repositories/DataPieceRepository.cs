using JobGuard.Domain.Entities;
using JobGuard.Domain.Primitives;
using JobGuard.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobGuard.Infrastructure.Postgres.Repositories;

public class DataPieceRepository(PostgresAppDbContext dbContext)
    : PostgresRepositoryBase(dbContext), IDataPieceRepository
{
    public void Create(DataPiece dataPiece)
    {
        DbContext.Add(dataPiece);    
    }

    public async Task<TEnt?> GetDataPiece<TEnt>(Guid id) where TEnt : Entity
    {
        var dataPiece = await DbContext.Set<DataPiece>().FirstOrDefaultAsync(x => x.Id == id);
        if (dataPiece == null)
            throw new ArgumentNullException($"Data piece {id} not found");

        var extId = Guid.Parse(dataPiece.ExternalId);
        var record = await DbContext.Set<TEnt>().FirstOrDefaultAsync(x => x.Id == extId);
        return record;
    }
}
