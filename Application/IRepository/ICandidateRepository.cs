using WebRecruitment.Application.IRepository.IGeneric;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository;

public interface ICandidateRepository : IGenericRepository<Candidate>
{
    Task<Candidate> GetCandidateById(Guid candidateId);
}