using AutoMapper;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Generic.Repository;

namespace WebRecruitment.Infrastructures.Repository;

public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
{

    public CompanyRepository(RecruitmentDbContext context) : base(context)
    {
    }

    public async Task<Guid> GetCompanyByName(string companyName)
    {
        var company =_context.Companies.FirstOrDefault(p => p.NameCompany == companyName);
        return company.CompanyId;
    }
    public async Task<Company> GetCompanyById(Guid companyId)
    {
        return await _context.Companies.FindAsync(companyId);
    }
}