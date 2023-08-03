using AutoMapper;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Generic.Repository;

namespace WebRecruitment.Infrastructures.Repository;

public class CvRepository : GenericRepository<Cv>, ICVRepository
{

    public CvRepository(RecruitmentDbContext context) : base(context)
    {
    }

    public async Task<Cv> GetCvDetail(Guid id)
    {
        var cvDetail = _context.Cvs.FirstOrDefault(c => c.CvId == id);
        return cvDetail;
    }
}