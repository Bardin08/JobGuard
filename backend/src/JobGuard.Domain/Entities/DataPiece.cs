using JobGuard.Domain.Primitives;

namespace JobGuard.Domain.Entities;

public class DataPiece : Entity
{
    private DataPiece(
        Guid id,
        Guid verificationId,
        string externalId,
        string type) : base(id)
    {
        ExternalId = externalId;
        VerificationId = verificationId;
        Type = type;
    }

    public Guid VerificationId { get; set; }
    public string ExternalId { get; private set; }
    public string Type { get; private set; }

    public static DataPiece Create(Guid verificationId, string externalId, string type)
        => new(Guid.NewGuid(), verificationId, externalId, type);
}

public enum DataPieceType
{
    Vacancy
}