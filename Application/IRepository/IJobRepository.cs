using WebRecruitment.Application.IRepository.IGeneric;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository;

public interface IJobRepository : IGenericRepository<Job>
{
    Task<Guid> GetJobByNameSkill(string nameSkill);
}