using JobGuard.Domain.Primitives;

namespace JobGuard.Domain.Entities;

public class Verification : Entity
{
    private Verification(
        Guid id,
        string providedDetails,
        List<string>? providedLinks) : base(id)
    {
        ProvidedDetails = providedDetails;
        _providedLinks = providedLinks ?? [];
        _dataPieces = [];

        ShortId = id.ToString("N")[..8];
        Status = VerificationStatus.Pending;
        CreatedAt = ModifiedAt = DateTimeOffset.UtcNow;
    }

    private readonly List<string> _providedLinks;
    private readonly List<DataPiece> _dataPieces;

    public IReadOnlyList<string> ProvidedLinks => _providedLinks;
    public IReadOnlyList<DataPiece> DataPieces => _dataPieces;

    public string ShortId { get; private set; }
    public string ProvidedDetails { get; private set; }
    public VerificationStatus Status { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset ModifiedAt { get; private set; }

    public static Verification Create(
        string providedDetails,
        List<string>? list = null)
    {
        return new Verification(Guid.NewGuid(), providedDetails, list);
    }

    public void AddDataPiece(DataPiece dataPiece)
    {
        _dataPieces.Add(dataPiece);
    }

    public void ChangeStatus(VerificationStatus newStatus)
    {
        Status = newStatus;
        ModifiedAt = DateTimeOffset.UtcNow;
    }
}

public enum VerificationStatus
{
    Pending,
    InProgress,
    WaitingForExternalResponse,
    Completed,
    Failed
}