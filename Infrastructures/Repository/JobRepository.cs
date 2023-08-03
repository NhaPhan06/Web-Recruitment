using AutoMapper;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Generic.Repository;

namespace WebRecruitment.Infrastructures.Repository;

public class JobRepository : GenericRepository<Job>, IJobRepository
{
    public JobRepository(RecruitmentDbContext context) : base(context)
    {
    }

    public async Task<Guid> GetJobByNameSkill(string nameSkill)
    {
        var job = _context.Jobs.FirstOrDefault(p => p.NameSkill == nameSkill);
        return job.JobId;
    }
}