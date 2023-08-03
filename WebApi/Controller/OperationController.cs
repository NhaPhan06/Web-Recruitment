using Application.Model.Request.InterviewerRequest;
using Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.Model.Request.OperationRequest;
using WebRecruitment.Application.Model.Response.OperationResponse;

namespace WebRecruitment.WebApi.Controllers;

//[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class OperationController : ControllerBase
{
    private readonly OperationService _operationService;

    public OperationController(OperationService operationService)
    {
        _operationService = operationService;
    }
    [HttpGet]
    public async Task<ActionResult<ResponseOperation>> GetAllApplyByPostId(Guid id)
    {
        var listApply = await _operationService.GetAllApplyByPostId(id);
        return listApply == null ? NotFound() : Ok(listApply);
    }

    [HttpPost]
    public async Task<ResponseOperation> CreateApplyJobByCandidate(RequestCreateOperation operation)
    {
        return await _operationService.CreateApplyJob(operation);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseOperation>> HRCheck(Guid id)
    {
        var changedStatus = await _operationService.HrCheck(id);
        return changedStatus == null ? NotFound() : Ok(changedStatus);
    }

    [HttpGet]
    public async Task<ActionResult<ResponseOperation>> GetStatusOperation(Guid id)
    {
        try
        {
            var operation = await _operationService.GetStatusOperation(id);
            return Ok(new
            {
                Success = true,
                Data = operation
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<ResponseOperation>> IntervieweCheckOperation(Guid id, bool status)
    {
        try
        {
            var operation = await _operationService.IntervieweCheck(id, status);
            return Ok(new
            {
                Success = true,
                Data = operation
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}