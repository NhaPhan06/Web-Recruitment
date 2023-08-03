namespace WebRecruitment.Application.Model.Response.AccountResponse;

public class LoginRespone
{
    public LoginRespone()
    {
        // Khởi tạo các thuộc tính
        Data = string.Empty;
        Success = false;
        Messenger = string.Empty;
    }

    public string Data { get; set; }
    public bool Success { get; set; }
    public string Messenger { get; set; }
}