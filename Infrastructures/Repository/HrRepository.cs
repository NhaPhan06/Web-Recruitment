using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Generic.Repository;

namespace WebRecruitment.Infrastructures.Repository;

public class HrRepository : GenericRepository<Hr>, IHrRepository
{

    public HrRepository(RecruitmentDbContext context) : base(context)
    {
    }

    public async Task<Hr> DeleteHr(Guid id)
    {
        try
        {
            var hr = await _context.Hrs!.FirstOrDefaultAsync(c => c.HrId == id);
            return hr;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message + "\nERROR REPOSITORY", ex);
        }
    }

    public async Task<Hr> GetByAccountId(Guid id)
    {
        return _context.Hrs.FirstOrDefault(hr => hr.Accountid == id);
    }

    public async Task<List<Hr>> GetAllHr()
    {
        try
        {
            var hr = await _context.Hrs!
                .Include(a => a.Account)
                .Include(p => p.Position)
                .Include(p => p.Posts)
                .Include(c => c.Company)
                .Include(m => m.Meetings)
                .Include(o => o.Operations)
                .ToListAsync();
            return hr;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message + "\nERROR REPOSITORY", ex);
        }
    }
}