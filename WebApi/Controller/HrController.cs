using Application.Model.Request.AccountRequest;
using Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.Model.Response.AccountResponse;

namespace WebApi.Controller;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class HrController : ControllerBase
{
    private readonly HrService _hrservice;

    public HrController(HrService hrservice)
    {
        _hrservice = hrservice;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponseAccountHr>>> GetHrs()
    {
        try
        {
            var response = await _hrservice.GetALLHr();

            return Ok(new
            {
                Success = true,
                Data = response
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch]
    public async Task<ActionResult<ResponseAccountHr>> GetHrStatus(Guid id)
    {
        try
        {
            var hr = await _hrservice.Delete(id);
            if (hr == null) return NotFound();
            return Ok(new
            {
                Success = true,
                Data = hr
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPatch]
    public async Task<ActionResult<ResponseAccountHr>> GetAccountInfor(Guid id, RequestUpdateAccount requestUpdateAccount)
    {
        try
        {
            var hr = await _hrservice.UpdateHrInfor(id, requestUpdateAccount);
            if (hr == null) return NotFound();
            return Ok(new
            {
                Success = true,
                Data = hr
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}