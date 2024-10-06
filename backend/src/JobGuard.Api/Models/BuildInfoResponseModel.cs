namespace JobGuard.Api.Models;

public class BuildInfoResponseModel
{
    public required string Version { get; set; }
    public required string CommitHash { get; set; }
    public required string Branch { get; set; }
    public required string BuildTime { get; set; }
    public required string BuildNumber { get; set; }
}