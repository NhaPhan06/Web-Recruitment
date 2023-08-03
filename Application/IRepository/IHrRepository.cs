using WebRecruitment.Application.IRepository.IGeneric;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository;

public interface IHrRepository : IGenericRepository<Hr>
{
    Task<List<Hr>> GetAllHr();
    Task<Hr> DeleteHr(Guid id);
    Task<Hr> GetByAccountId(Guid id);
}