using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Generic.Repository;

namespace WebRecruitment.Infrastructures.Repository;

public class OperationRepository : GenericRepository<Operation>, IOperationRepository
{


    public OperationRepository(RecruitmentDbContext context) : base(context)
    {
    }
    public async Task<List<Operation>> GetByPostId(Guid id)
    {
        return await _context.Operations.Where(postId => postId.PostId == id)
                                        .Include(cv => cv.Cv)
                                        .Include(hr => hr.Hr)
                                        .Include(company => company.Company)
                                        .Include(post => post.Post)
                                        .Include(job => job.Post.Job)
                                        .ToListAsync();
    }

    public async Task<List<Operation>> GetOperationByStatus(string status)
    {
        return await _context.Operations.Where(s => s.Status.Equals(status)).ToListAsync();
    }

    public async Task<Operation> GetStatus(Guid id)
    {
        return await _context.Operations.FirstOrDefaultAsync(o => o.OperationId == id);
    }
}