using Application.Model.Request.MeetRequest;
using Application.Model.Response.MeetingResponse;
using Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.Model.Request.MeetRequest;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly MeetingService _meetingService;
        public MeetingController(MeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MeetingResponse>>> GetAllMeeting()
        {
            try
            {
                var meetings = await _meetingService.GetAllMeeting();
                return Ok(meetings);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<MeetingResponse>> GetMeetingById(Guid id)
        {
            try
            {
                var meeting = await _meetingService.GetMeetingById(id);
                return Ok(meeting);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<MeetingResponse>> GetActivatedMeeting()
        {
            try
            {
                var meetings = await _meetingService.GetActivatedMeeting();
                return Ok(meetings);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<MeetingResponse>> GetInActivatedMeeting()
        {
            try
            {
                var meetings = await _meetingService.GetInactivatedMeeting();
                return Ok(meetings);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<MeetingResponse>> CreateMeeting(MeetingRequest meeting)
        {
            try
            {
                var createMeeting = await _meetingService.CreateMeeting(meeting);
                return Ok(createMeeting);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<MeetingResponse>> UpdateMeeting(Guid id, MeetingUpdateRequest meetingRequest)
        {
            try
            {
                var update = _meetingService.UpdateMeeting(id, meetingRequest);
                return Ok(update);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteMeeting(Guid id)
        {
            try
            {
                return Ok(_meetingService.DeleteMeeting(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
