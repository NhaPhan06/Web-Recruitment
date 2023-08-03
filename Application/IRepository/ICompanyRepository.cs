using WebRecruitment.Application.IRepository.IGeneric;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository;

public interface ICompanyRepository : IGenericRepository<Company>
{
    Task<Guid> GetCompanyByName(string companyName);
    Task<Company> GetCompanyById(Guid companyId);
}