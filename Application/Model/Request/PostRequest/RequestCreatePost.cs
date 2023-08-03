using System.ComponentModel.DataAnnotations;

namespace WebRecruitment.Application.Model.Request.PostRequest;

public class RequestCreatePost
{
    public Guid JobId { get; set; }

    public Guid HrId { get; set; }

    [Required(ErrorMessage = "The Title field is required.")]
    public string Title { get; set; } = null!;

    public DateTime PeriodDate { get; set; }

    public DateTime ExpiredDate { get; set; }

    [Required(ErrorMessage = "The Location field is required.")]
    public string Location { get; set; } = null!;
    
    [Range(10000, 1000000000, ErrorMessage = "Min: 10000 Max: 1000000000")]
    public double Salary { get; set; }

    [Required(ErrorMessage = "The EmploymentType field is required.")]
    public string EmploymentType { get; set; } = null!;

    [Required(ErrorMessage = "The Requirements field is required.")]
    public string Requirements { get; set; } = null!;
}