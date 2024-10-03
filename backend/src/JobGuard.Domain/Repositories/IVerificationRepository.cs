using JobGuard.Domain.Entities;

namespace JobGuard.Domain.Repositories;

public interface IVerificationRepository
{
    void Create(Verification verification);
    void Update(Verification verification);
    Task<Verification?> GetByShortId(string verificationId);
    Task<Verification?> GetById(Guid verificationId);
}