using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace JobGuard.Application.Abstractions.Behaviors;

internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(
    ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        logger.LogInformation("Processing request {RequestName}", requestName);

        try
        {
            var response = await next();

            logger.LogInformation("Processing request {RequestName} completed", requestName);

            return response;
        }
        catch (Exception e)
        {
            using (LogContext.PushProperty("Error", e, true))
            {
                logger.LogError(e, "Completed request {RequestName} with error", requestName);
            }

            throw;
        }
    }
}
