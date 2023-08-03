using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Generic.Repository;

namespace WebRecruitment.Infrastructures.Repository;

public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
{
    public CandidateRepository(RecruitmentDbContext context) : base(context)
    {
    }

    public async Task<Candidate> GetCandidateById(Guid candidateId)
    {
        return await _context.Candidates.FirstOrDefaultAsync(c => c.CandidateId == candidateId);
    }
}