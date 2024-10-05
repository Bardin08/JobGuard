using System.Text;
using JobGuard.Application.Abstractions.Messaging;
using JobGuard.Application.DataCollection.Commands;
using JobGuard.Application.Vacancies.Commands;
using JobGuard.Domain.Entities;
using JobGuard.Domain.Repositories;
using MediatR;

namespace JobGuard.Application.Verifications.Commands;

public record ProcessVerificationCommand(Guid VerificationId) : ICommand;

public class ProcessVerificationCommandHandler(IVerificationRepository verificationRepository, ISender mediator)
    : ICommandHandler<ProcessVerificationCommand>
{
    private readonly IVerificationRepository _verificationRepository = verificationRepository;
    private readonly ISender _mediator = mediator;

    public async Task Handle(ProcessVerificationCommand request, CancellationToken cancellationToken)
    {
        var verification = await _verificationRepository.GetById(request.VerificationId);
        if (verification is null)
            // TODO: Replace with appropriate exception
            throw new ArgumentException($"Verification with id {request.VerificationId} not found.");

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