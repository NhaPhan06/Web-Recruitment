using Application.Model.Response.MeetingResponse;
using Azure;
using WebRecruitment.Application.IRepository.IGeneric;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository;

public interface IMeetingRepository : IGenericRepository<Meeting>
{
    Task<List<Meeting>> GetActivatedMeeting();
    Task<List<Meeting>> GetInActivatedMeeting();
}