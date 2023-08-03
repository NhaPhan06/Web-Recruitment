using System.Net;
using Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Model.Request.InterviewerRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;

namespace WebRecruitment.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly AuthenticationService _authentication;
    private readonly IUnitOfWork _unitOfWork;

    public AuthenticationController(AuthenticationService authentication, IUnitOfWork unitOfWork)
    {
        _authentication = authentication;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponseAllAccount>>> GetAllAccounts()
    {
        try
        {
            var account = _unitOfWork.Account.GetAll();
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = account
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Success = HttpStatusCode.InternalServerError,
                Message = "Failed",
                Data = ex.Message
            });
        }
    }
    

    [HttpPost]
    public async Task<ActionResult<LoginRespone>> Login(RequestLogin login)
    {
        var user = _authentication.Validate(login);
        //cấp token
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<ActionResult<Boolean>> Logout(Guid AccountId)
    {
        var user = _authentication.Logout(AccountId);
        //cấp token
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseAccountAdmin>> CreateAdminAccount(
        RequestAccountToAdmin requestAccountToAdmin)
    {
        var admin = await _authentication.CreateAccountAdmin(requestAccountToAdmin);

        return admin == null
            ? NotFound()
            : Ok(new
            {
                Success = true,
                Data = admin
            });
    }


    [HttpPost]
    public async Task<ActionResult<ResponseAccountCandidate>> CreateCandidateAccount(
        RequestAccountToCadidate requestAccountToCandidate)
    {
        var candidate = await _authentication.CreateAccountCandidate(requestAccountToCandidate);
        return candidate == null
            ? NotFound()
            : Ok(new
            {
                Success = true,
                Data = candidate
            });
    }

    [HttpPost]
    public async Task<ActionResult<ResponseAccountCompany>> CreateCompanyAccount(
        RequestAccountToCompany requestAccountToCompany)
    {
        var company = await _authentication.CreateAccountCompany(requestAccountToCompany);
        return company == null
            ? NotFound()
            : Ok(new
            {
                Success = true,
                Data = company
            });
    }

    [HttpPost]
    public async Task<ActionResult<ResponseAccountHr>> CreateHrAccount(
        RequestAccountToHr requestAccountToHr)
    {
        var hr = await _authentication.CreateAccountHr(requestAccountToHr);
        return hr == null
            ? NotFound()
            : Ok(new
            {
                Success = true,
                Data = hr
            });
    }

    [HttpPost]
    public async Task<ActionResult<ResponseAccountInterviewer>> CreateInterviewerAccount(
        RequestAccountToInterviewer requestAccountToInterviewer)
    {
        var interviewer = await _authentication.CreateAccountInterviewer(requestAccountToInterviewer);
        return interviewer == null
            ? NotFound()
            : Ok(new
            {
                Success = true,
                Data = interviewer
            });
    }

    [HttpPost]
    public async Task<IActionResult> ForgetPassword(string email)
    {
        bool check = await _authentication.ForgetPassword(email);
        if (check is true)
        {
            return Ok(new
            {
                Success = true,
                Messager = "Reset OTP have send to your mail"
            });
        }

        return NotFound(new
        {
            Success = false,
            Messager = "Your Mail not Exist"
        });
    }

    [HttpPost]
    public async Task<IActionResult> RessetPassword(string email, string password, string token)
    {
        bool check = await _authentication.ResetPassword(email, password, token);
        if (check is true)
        {
            return Ok(new
            {
                Success = true,
                Messager = "Resset Password Success"
            });
        }

        return NotFound(new
        {
            Success = false,
            Messager = "OTP Is Wrong"
        });
    }
}