using Application.Model.Request.CandidateRequest;
using Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.OperationResponse;

namespace WebApi.Controller;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class CandidateController : ControllerBase
{
    private readonly CandidateService _candidateService;

    public CandidateController(CandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseOperation>> ViewApplyByStatus(string status)
    {
        try
        {
            var applies = await _candidateService.GetOperationByStatus(status);
            return Ok(applies);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<ResponseAccountCandidate>> GetAllCandidates()
    {
        try
        {
            var candidates = await _candidateService.GetAllCandidatesAccount();
            return Ok(candidates);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }


    [HttpPut]
    public async Task<IActionResult> UpdateCandidate(Guid candidateId, [FromBody] RequestUpdateCandidate updateRequest)
    {
        try
        {
            var response = await _candidateService.UpdateCandidateInfor(candidateId, updateRequest);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}