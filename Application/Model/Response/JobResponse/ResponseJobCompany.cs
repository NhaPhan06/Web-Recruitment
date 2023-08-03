namespace WebRecruitment.Application.Model.Response.JobResponse;

public class ResponseJobCompany
{
    public Guid JobId { get; set; }
    public Guid CompanyId { get; set; }
    public string NameSkill { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Status { get; set; }
}