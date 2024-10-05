using FluentValidation;
using Jobby.Domain.Repositories;
using JobGuard.Application.Abstractions.Messaging;
using JobGuard.Application.Verifications.Jobs;
using JobGuard.Domain.Entities;
using JobGuard.Domain.Repositories;
using Quartz;

namespace JobGuard.Application.Verifications.Commands;

public record ExecuteVerificationCommand(string VerificationId) : ICommand;

internal class ExecuteVerificationCommandValidator : AbstractValidator<ExecuteVerificationCommand>
{
    public ExecuteVerificationCommandValidator()
    {
        RuleFor(x => x.VerificationId)
            .NotEmpty().WithMessage("Verification Id is required.")
            .Length(12).WithMessage("Verification Id must be 12 characters.")
            .Must(x => x.StartsWith("ver-")).WithMessage("Verification id must start with 'ver-'");
    }
}

internal class ExecuteVerificationCommandHandler(
    ISchedulerFactory schedulerFactory,
    IVerificationRepository verificationRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<ExecuteVerificationCommand>
{
    private readonly ISchedulerFactory _schedulerFactory = schedulerFactory;
    private readonly IVerificationRepository _verificationRepository = verificationRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(ExecuteVerificationCommand request, CancellationToken cancellationToken)
    {
        var verificationId = request.VerificationId[4..];

        var verification = await _verificationRepository.GetByShortId(verificationId);
        if (verification is null)
            // TODO: Replace with appropriate exception
            throw new ArgumentException($"Verification with id {verificationId} not found.");

        if (verification.Status is not VerificationStatus.Pending)
            throw new InvalidOperationException($"Verification with id {verificationId} has already executed.");

        verification.ChangeStatus(VerificationStatus.InProgress);
        _verificationRepository.Update(verification);

        await ExecuteVerificationProcessingBackgroundJob(cancellationToken, verification);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private async Task ExecuteVerificationProcessingBackgroundJob(CancellationToken cancellationToken,
        Verification verification)
    {
        var scheduler = await _schedulerFactory.GetScheduler(cancellationToken);

        var jobKey = new JobKey(nameof(ProcessVerificationBackgroundJob));

        var jobDetail = JobBuilder.Create<ProcessVerificationBackgroundJob>()
            .WithIdentity(jobKey)
            .StoreDurably()
            .Build();

        if (!await scheduler.CheckExists(jobKey, cancellationToken))
            await scheduler.AddJob(jobDetail, true, cancellationToken);

        var jobDataMap = new JobDataMap();
        jobDataMap.Add("verificationId", verification.Id);

        await scheduler.TriggerJob(jobKey, jobDataMap, cancellationToken);
    }
}