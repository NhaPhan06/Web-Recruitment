using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Application.Model.Response.PostResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Generic.Repository;

namespace WebRecruitment.Infrastructures.Repository;

public class PostRepository : GenericRepository<Post>, IPostRepository
{

    public PostRepository(RecruitmentDbContext context) : base(context)
    {
    }

    public Task<List<Post>> GetPostByCompanyID(Guid companyId)
    {
        return  _context.Posts.Include(c => c.Hr).Include(c => c.Job).Include(c => c.Company).Where(p => p.CompanyId.Equals(companyId)).ToListAsync();
        return _context.Posts.Where(p => p.CompanyId.Equals(companyId)).ToListAsync();
    }

    public Task<List<Post>> GetPostByLocation(string location, string nameSkill)
    {
        var post = _context.Posts.Include(c =>c.Hr).Include(c=>c.Job).Include(c=>c.Company).Where(p => p.Location == location && p.Job.NameSkill == nameSkill).ToListAsync();
        return post;
    }

    public Task<List<Post>> GetPostByNameSkill(Guid jobId)
    {
        return _context.Posts.Include(c => c.Hr).Include(c => c.Job).Include(c => c.Company).Where(p => p.JobId.Equals(jobId)).ToListAsync();
    }

    public Task<List<Post>> GetPostBySalary(double salary, string nameSkill)
    {
        var post = _context.Posts.Include(c => c.Hr).Include(c => c.Job).Include(c => c.Company)
            .Where(p => p.Salary >= salary  && p.Job.NameSkill == nameSkill).ToListAsync();
        return post;
    }

    public async Task<List<Post>> GetAllPost()
    {
        var posts = await _context.Posts.Include(c => c.Company).Include(c => c.Job).Include(c => c.Hr).ToListAsync();
        return posts;
    }

    public async Task<Post> GetAllPostDetail(Guid id)
    {
        var posts = await _context.Posts.Include(c => c.Company).Include(c => c.Job).Include(c => c.Hr).FirstOrDefaultAsync(p => p.PostId == id);
        return posts;

    }
    
}