namespace JobGuard.Application.Models.DataCollection;

public record LinkContentDto
{
    public required string Url { get; init; }
    public required string Content { get; init; }
    public List<string>? CollectedLinks { get; init; }
}