namespace JobGuard.Api.Extensions;

public static class HttpRequestsExtensions
{
    public static string GetBaseUrl(this HttpRequest request)
        => $"{request.Scheme}://{request.Host}{request.PathBase}";
}