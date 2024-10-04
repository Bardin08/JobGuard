using FluentValidation;
using Jobby.Domain.Repositories;
using JobGuard.Application.Abstractions.Messaging;
using JobGuard.Domain.Entities;
using JobGuard.Domain.Repositories;

namespace JobGuard.Application.Verifications.Commands;

public record CreateVerificationCommand(string Details) : ICommand<string>;

internal class CreateVerificationCommandValidator : AbstractValidator<CreateVerificationCommand>
{
    public CreateVerificationCommandValidator()
    {
        RuleFor(x => x.Details)
            .NotEmpty().WithMessage("Details cannot be empty.")
            .MaximumLength(256).WithMessage("Details cannot exceed 256 characters.")
            .Must(detail =>
                ContainsUrl(detail) ||
                detail.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length >= 50)
            .WithMessage("Details must contain at least 50 words or include a valid URL somewhere in the text.");
        return;

        bool ContainsUrl(string detail)
        {
            var words = detail.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return words.Any(word => Uri.IsWellFormedUriString(word, UriKind.Absolute));
        }
    }
}

internal class CreateVerificationCommandHandler(IVerificationRepository repository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateVerificationCommand, string>
{
    private readonly IVerificationRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<string> Handle(CreateVerificationCommand request, CancellationToken cancellationToken)
    {
        var links = ExtractUrls(request.Details);

        var verification = Verification.Create(request.Details, links);
        _repository.Create(verification);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return "ver-" + verification.ShortId;
    }

    private List<string> ExtractUrls(string detail)
    {
        var urls = new List<string>();
        var words = detail.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            if (Uri.IsWellFormedUriString(word, UriKind.Absolute))
            {
                urls.Add(word);
            }
        }
    
        return urls;
    }
}