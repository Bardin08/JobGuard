using FluentValidation;
using Jobby.Domain.Repositories;
using JobGuard.Application.Abstractions.Messaging;
using JobGuard.Application.Abstractions.Services;
using JobGuard.Domain.Entities;
using JobGuard.Domain.Repositories;
using MediatR;

namespace JobGuard.Application.Vacancies.Commands;

public record CreateVacancyCommand(
    string Description,
    string Source,
    Guid VerificationId) : ICommand;

public class CreateVacancyCommandValidator : AbstractValidator<CreateVacancyCommand>
{
    public CreateVacancyCommandValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
    }
}

public class CreateVacancyCommandHandler(
    IOpenAiService openAiService,
    IVacancyRepository vacancyRepository,
    IDataPieceRepository dataPieceRepository,
    IVerificationRepository verificationRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateVacancyCommand>
{
    private readonly IOpenAiService _openAiService = openAiService;
    private readonly IVacancyRepository _vacancyRepository = vacancyRepository;
    private readonly IDataPieceRepository _dataPieceRepository = dataPieceRepository;
    private readonly IVerificationRepository _verificationRepository = verificationRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
    {
        var vacancyDto = await _openAiService.GetVacancyFromDescription(request.Description, cancellationToken);

        var vacancy = VacancyDetails.Create(
            vacancyDto.JobTitle,
            vacancyDto.JobDescription,
            vacancyDto.JobLocation,
            vacancyDto.SalaryRange,
            vacancyDto.EmploymentType,
            vacancyDto.PostedDate ?? DateTimeOffset.MinValue,
            vacancyDto.ApplicationDeadline,
            vacancyDto.Responsibilities,
            vacancyDto.Qualifications,
            Domain.Constants.DefaultCompanyId // TODO: replace with real company ID
        );

        vacancy.AddSource(request.Source);

        _vacancyRepository.Create(vacancy);

        await LinkVacancyToVerification(request, vacancy);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private async Task LinkVacancyToVerification(CreateVacancyCommand request, VacancyDetails vacancy)
    {
        var verification = await _verificationRepository.GetById(request.VerificationId);
        if (verification == null)
            throw new ArgumentNullException($"Verification {request.VerificationId} not found");

        var dataPiece = DataPiece.Create(verification.Id, vacancy.Id.ToString(), DataPieceType.Vacancy.ToString());
        _dataPieceRepository.Create(dataPiece);

        verification.AddDataPiece(dataPiece);

        _verificationRepository.Update(verification);
    }
}