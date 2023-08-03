using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Domain.Entity;

namespace WebApi.Controller;


[Route("api/[controller]/[action]")]
[ApiController]
public class PositionController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PositionController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Position>>> GetAllAccounts()
    {
        try
        {
            var account = _unitOfWork.Position.GetAll();
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
    
    
    [HttpPost] // /Mail?recipientEmail=toSomeOne@gmail.com&subject=subject&content=hello
    public async Task GetAsync()
    {
       var fromAddress = new MailAddress("thosanquy053@gmail.com");
        var toAddress = new MailAddress("phanthanhnha06@gmail.com");

        var smtpClient = new SmtpClient("smtp.gmail.com", 587)
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("thosanquy053@gmail.com", "nhapvpse150408"),
            EnableSsl = true
        };

        var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = "hello",
            Body = "hello"
        };

        await smtpClient.SendMailAsync(message);
    }

}