using JobGuard.Domain.Entities;
using JobGuard.Domain.Primitives;

namespace JobGuard.Domain.Repositories;

public interface IDataPieceRepository
{
    void Create(DataPiece dataPiece);
    Task<TEnt?> GetDataPiece<TEnt>(Guid id) where TEnt : Entity;
}