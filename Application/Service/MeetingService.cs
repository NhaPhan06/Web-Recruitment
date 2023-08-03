using Application.Model.Request.MeetRequest;
using Application.Model.Response.MeetingResponse;
using WebRecruitment.Application.Model.Request.MeetRequest;

namespace Application.Service;

public interface MeetingService
{
    Task<List<MeetingResponse>> GetAllMeeting();
    Task<MeetingResponse> GetMeetingById(Guid id);
    Task<MeetingResponse> CreateMeeting(MeetingRequest meetingRequest);
    Task DeleteMeeting(Guid meetingId);
    Task<MeetingResponse> UpdateMeeting(Guid id, MeetingUpdateRequest meetingRequest);
    Task<List<MeetingResponse>> GetActivatedMeeting();
    Task<List<MeetingResponse>> GetInactivatedMeeting();
}