namespace WebRecruitment.Application.Model.Request.JobRequest;

public class RequestJobCompany
{
    public Guid? CompanyId { get; set; }
    public string NameSkill { get; set; } = null!;
    public string Description { get; set; } = null!;
}