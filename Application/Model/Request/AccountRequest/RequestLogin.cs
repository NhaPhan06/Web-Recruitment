namespace WebRecruitment.Application.Model.Request.AccountRequest;

public class RequestLogin
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}