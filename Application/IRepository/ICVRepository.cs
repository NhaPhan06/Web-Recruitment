using WebRecruitment.Application.IRepository.IGeneric;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository;

public interface ICVRepository : IGenericRepository<Cv>
{
    Task<Cv> GetCvDetail(Guid id);
}