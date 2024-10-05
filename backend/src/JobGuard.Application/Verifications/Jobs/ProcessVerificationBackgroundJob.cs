using JobGuard.Application.Verifications.Commands;
using MediatR;
using Quartz;

namespace JobGuard.Application.Verifications.Jobs;

public class ProcessVerificationBackgroundJob(ISender mediator) : IJob
{
    private readonly ISender _mediator = mediator;

    public async Task Execute(IJobExecutionContext context)
    {
        var verificationId = context.MergedJobDataMap["verificationId"] as Guid? ?? default;
        if (verificationId == default)
            throw new ArgumentException("Verification Id is required.");

        var processVerificationCommand = new ProcessVerificationCommand(verificationId);
        
        await _mediator.Send(processVerificationCommand);
    }
}