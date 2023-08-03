using WebRecruitment.Application.IRepository.IGeneric;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository;

public interface IOperationRepository : IGenericRepository<Operation>
{
    Task<List<Operation>> GetOperationByStatus(string status);
    Task<Operation> GetStatus(Guid id);
    Task<List<Operation>> GetByPostId(Guid id);
}