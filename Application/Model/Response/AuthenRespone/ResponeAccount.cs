namespace WebRecruitment.Application.Model.Response.AuthenRespone;

public class ResponeAccount
{
    public Guid AccountId { get; set; }
    public Guid HrId { get; set; }
    public Guid InterviewerId { get; set; }
    public string Role { get; set; }
    public string HashPassword { get; set; }
}