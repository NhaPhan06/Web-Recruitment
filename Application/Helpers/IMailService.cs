namespace Application.Helpers;

public interface IMailService
{
    Task SendEmail(Model.Request.Mail request);
}