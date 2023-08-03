namespace WebRecruitment.Application.Model.Request.HrRequest;

public class RequestUpdateStatusApply
{
    public RequestUpdateStatusApply()
    {
    }

    public RequestUpdateStatusApply(string status)
    {
        Status = status;
    }

    public string Status { get; set; }
}