using Application.Model.Request.MeetRequest;
using Application.Model.Response.MeetingResponse;
using AutoMapper;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Application.Model.Request.MeetRequest;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums.Status;

namespace Application.Service.Implement;

public class MeetingImplement : MeetingService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMeetingRepository _meeting;

    public MeetingImplement(IMapper mapper, IUnitOfWork unitOfWork, IMeetingRepository meeting)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _meeting = meeting;
    }

    public async Task<MeetingResponse> CreateMeeting(MeetingRequest meetingRequest)
    {
        var createMeeting = _mapper.Map<Meeting>(meetingRequest);
        var hr = _unitOfWork.Hr.GetById(meetingRequest.HrId);
        if (hr == null)
        {
            throw new Exception("Hr does not exist");
        }
        createMeeting.HrId = hr.HrId;
        createMeeting.Status = MeetingEnum.ACTIVE.ToString();
        createMeeting.StartTime = DateTime.Now;
        createMeeting.EndTime = createMeeting.StartTime.AddHours(1);
        _unitOfWork.Meeting.Add(createMeeting);
        _unitOfWork.Save();
        return _mapper.Map<MeetingResponse>(createMeeting);
    }

    public async Task DeleteMeeting(Guid meetingId)
    {
        var meeting = _unitOfWork.Meeting.GetById(meetingId);
        if (meeting is null)
        {
            throw new Exception("Can not found by" + meetingId);
        }
        meeting.Status = MeetingEnum.INACTIVE.ToString();
        _unitOfWork.Meeting.Update(meeting);
        _unitOfWork.Save();
    }

    public async Task<MeetingResponse> UpdateMeeting(Guid id, MeetingUpdateRequest meetingRequest)
    {
        var meeting = _unitOfWork.Meeting.GetById(id);
        if (meeting is null)
        {
            throw new Exception("Can not found ");
        }
        meeting.LinkMeet = meetingRequest.LinkMeet;
        meeting.StartTime = meetingRequest.StartTime;
        meeting.EndTime = meetingRequest.EndTime.AddHours(1);
        meeting.Status = meetingRequest.Status;
        _unitOfWork.Meeting.Update(meeting);
        _unitOfWork.Save();
        return _mapper.Map<MeetingResponse>(meeting);
    }

    public async Task<List<MeetingResponse>> GetAllMeeting()
    {
        var meetings = _unitOfWork.Meeting.GetAll();
        if (meetings is null)
        {
            throw new Exception("List is empty");
        }
        return _mapper.Map<List<MeetingResponse>>(meetings);
    }

    public async Task<MeetingResponse> GetMeetingById(Guid id)
    {
        var meeting = _unitOfWork.Meeting.GetById(id);
        if (meeting is null)
        {
            throw new Exception("Can not found by " + id);
        }
        return _mapper.Map<MeetingResponse>(meeting);
    }

    public async Task<List<MeetingResponse>> GetActivatedMeeting()
    {
        var activatedMeeting = await _meeting.GetActivatedMeeting();
        if (activatedMeeting.Count == 0)
        {
            throw new Exception("Empty list");
        }
        return _mapper.Map<List<MeetingResponse>>(activatedMeeting);
    }

    public async Task<List<MeetingResponse>> GetInactivatedMeeting()
    {
        var inActivatedList = await _meeting.GetInActivatedMeeting();
        if (inActivatedList.Count == 0)
        {
            throw new Exception("Empty list");
        }
        return _mapper.Map<List<MeetingResponse>>(inActivatedList);
    }
}