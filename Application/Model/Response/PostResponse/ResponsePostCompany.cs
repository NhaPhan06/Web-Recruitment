namespace WebRecruitment.Application.Model.Response.PostResponse;

public class ResponsePostCompany
{
    public Guid CompanyId { get; set; }
    public string NameCompany { get; set; }
    public Guid PostId { get; set; }

    public Guid JobId { get; set; }
    public Guid HrId { get; set; }
    public string hrName { get; set; } = null!;

    public string NameSkill { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Title { get; set; } = null!;

    public DateTime PeriodDate { get; set; }

    public DateTime ExpiredDate { get; set; }

    public string Location { get; set; } = null!;

    public double Salary { get; set; }

    public string EmploymentType { get; set; } = null!;

    public string Requirements { get; set; } = null!;
    public string StatusPost { get; set; } = null!;
}