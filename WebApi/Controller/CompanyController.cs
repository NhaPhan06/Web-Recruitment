using Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.Model.Request.CompanyRequest;
using WebRecruitment.Application.Model.Response.CompanyResponse;

namespace WebRecruitment.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CompanyController : ControllerBase
{
    private readonly CompanyService _companyService;

    public CompanyController(CompanyService companyService)
    {
        _companyService = companyService;
    }
    [HttpGet]
    public async Task<ActionResult<ResponseOfCompany>> GetAllCompanies()
    {
        try
        {
            var companies = await _companyService.GetAllCompany();
            return Ok(companies);

        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<ResponseOfCompany>> UpdateCompany(Guid companyId, UpdateRequestCompany updateRequest)
    {
        try
        {
            var response = await _companyService.UdpateCompanyInfor(companyId, updateRequest);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
