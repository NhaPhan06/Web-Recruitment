using Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Application.Model.Request.JobRequest;
using WebRecruitment.Application.Model.Response.JobResponse;

namespace WebApi.Controller;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class JobController : ControllerBase
{
    private readonly JobService _jobService;

    public JobController(JobService jobService)
    {
        _jobService = jobService;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseJobCompany>> CreateJob(RequestJobCompany requestJobCompany)
    {
        var result = await _jobService.CreateJob(requestJobCompany);
        return result == null ? NotFound() : Ok(result);
    }
}