using Application.Model.Request.AccountRequest;
using Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.Model.Response.AccountResponse;

namespace WebApi.Controller;

//[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class InterviewerController : ControllerBase
{
    private readonly InterviewerService _interviewerService;

    public InterviewerController(InterviewerService interviewerService)
    {
        _interviewerService = interviewerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ResponseAccountInterviewer>>> GetAllInterviewers()
    {
        try
        {
            var interviewer = await _interviewerService.GetAllInterviewers();
            return Ok(interviewer);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<ResponseAccountInterviewer>> GetInterviewerById(Guid id)
    {
        try
        {
            var interviewer = await _interviewerService.GetInterviewerById(id);
            return Ok(interviewer);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<ResponseAccountInterviewer>>> GetInterviewerByName(string name)
    {
        try
        {
            var interviewer = await _interviewerService.GetInterviewerByName(name);
            return Ok(interviewer);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPatch]
    public async Task<ActionResult<ResponseAccountInterviewer>> SetStatusInterviewer(Guid id)
    {
        try
        {
            var interviewer = await _interviewerService.SetStatusInterviewer(id);
            return Ok(interviewer);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpPatch]
    public async Task<ActionResult<ResponseAccountHr>> GetAccountInfor(Guid id, RequestUpdateAccount requestUpdateAccount)
    {
        try
        {
            var interviewer = await _interviewerService.UpdateInterInfor(id, requestUpdateAccount);
            if (interviewer == null) return NotFound();
            return Ok(new
            {
                Success = true,
                Data = interviewer
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}