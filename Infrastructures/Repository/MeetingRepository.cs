using Application.Model.Response.MeetingResponse;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums.Status;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Generic.Repository;

namespace WebRecruitment.Infrastructures.Repository;

public class MeetingRepository : GenericRepository<Meeting>, IMeetingRepository
{

    public MeetingRepository(RecruitmentDbContext context) : base(context)
    {
    }

    public async Task<List<Meeting>> GetActivatedMeeting()
    {
        var activatedList = await _context.Meetings.Where(status => status.Status.Equals(MeetingEnum.ACTIVE.ToString())).ToListAsync();
        return activatedList;
    }

    public async Task<List<Meeting>> GetInActivatedMeeting()
    {
        var inActivatedList =await _context.Meetings.Where(status => status.Status.Equals(MeetingEnum.INACTIVE.ToString())).ToListAsync();
        return inActivatedList;
    }
}