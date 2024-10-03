using System.Text;
using FluentValidation;
using JobGuard.Application.Abstractions.Messaging;
using JobGuard.Application.DataCollection.Commands;
using JobGuard.Application.Vacancies.Commands;
using JobGuard.Domain.Entities;
using JobGuard.Domain.Repositories;
using MediatR;

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

internal class ExecuteVerificationCommandHandler(ISender mediator, IVerificationRepository repository)
    : ICommandHandler<ExecuteVerificationCommand>
{
    private readonly ISender _mediator = mediator;
    private readonly IVerificationRepository _repository = repository;

    public async Task Handle(ExecuteVerificationCommand request, CancellationToken cancellationToken)
    {
        var verificationId = request.VerificationId[4..];

        var verification = await _repository.GetByShortId(verificationId);
        if (verification is null)
            // TODO: Replace with appropriate exception
            throw new ArgumentException($"Verification with id {verificationId} not found.");

        if (verification.Status is not VerificationStatus.Pending)
            throw new InvalidOperationException($"Verification with id {verificationId} has already been pending.");

        var description = await NormalizeProvidedDetails(cancellationToken, verification);

        var createVacancyCommand = new CreateVacancyCommand(
            description,
            DataSourceType.ProvidedDescription.ToString(),
            verification.Id);
        
        await _mediator.Send(createVacancyCommand, cancellationToken);
    }

    private async Task<string> NormalizeProvidedDetails(CancellationToken cancellationToken, Verification verification)
    {
        var description = verification.ProvidedDetails;
        if (verification.ProvidedLinks.Count > 0)
        {
            var linksContent = await GetContentFromLinks(verification.ProvidedLinks, cancellationToken);

            description += linksContent;
        }

        description = description
            .Replace("\n", " ")
            .Replace("\t", " ")
            .Replace("\r", " ");
        return description;
    }

    private async Task<string> GetContentFromLinks(IReadOnlyList<string> links, CancellationToken cancellationToken)
    {
        var tasks = links.Select(async x =>
        {
            var command = new FetchDataFromLinkCommand(Url: x, CollectLinks: false, AsPlainText: true);
            return await _mediator.Send(command, cancellationToken);
        });

        var linkContentDtos = await Task.WhenAll(tasks);

        var stringBuilder = new StringBuilder();
        
        foreach (var linkContentDto in linkContentDtos)
            stringBuilder.AppendLine().AppendLine(linkContentDto.Content);

        return stringBuilder.ToString();
    }
}