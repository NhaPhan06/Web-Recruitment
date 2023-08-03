using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Generic.Repository;

namespace WebRecruitment.Infrastructures.Repository;

public class InterviewerRepository : GenericRepository<Interviewer>, IInterviewerRepository
{

    public InterviewerRepository(RecruitmentDbContext context) : base(context)
    {
    }

    public async Task<List<Interviewer>> GetAllInterviewers()
    {
        var interviewer = await _context.Interviewers
            .Include(i => i.Account)
            .Include(i => i.Company)
            .Include(i => i.Position)
            .ToListAsync();
        return interviewer;
    }

    public async Task<Interviewer> GetByAccountId(Guid id)
    {
        return await _context.Interviewers.FirstOrDefaultAsync(i => i.Accountid == id);
    }

    public async Task<Interviewer> SetStatusInterviewer(Guid id)
    {
        return await _context.Interviewers.FirstOrDefaultAsync(i => i.InterviewerId == id);
    }

    public async Task<Interviewer> GetInterviewerById(Guid id)
    {
        var interviewer = await _context.Interviewers
            .Include(i => i.Account)
            .Include(i => i.Company)
            .Include(i => i.Position)
            .FirstOrDefaultAsync(i => i.InterviewerId == id);
        return interviewer;
    }

    public async Task<List<Interviewer>> GetInterviewerByName(string name)
    {
        var interviewer = await _context.Interviewers
            .Include(i => i.Account)
            .Include(i => i.Company)
            .Include(i => i.Position)
            .Where(i => i.NameInterviewer.Contains(name))
            .ToListAsync();
        return interviewer;
    }
}