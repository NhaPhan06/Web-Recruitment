using System.ComponentModel.DataAnnotations;

namespace WebRecruitment.Application.Model.Request.CompanyRequest;

public class UpdateRequestCompany
{
    public Guid CompanyId { get; set; }
    public string? Description { get; set; }
    public int? Size { get; set; }
    public DateTime? FoundingYear { get; set; }
    public string? Logo { get; set; }
    public string? Benefits { get; set; }
    public string? Industry { get; set; }
    public string? Website { get; set; }
    [RegularExpression(@"^[0-9]{8,9}$", ErrorMessage = "The phone number must be an 8 or 9 digit integer.")]
    [Required(ErrorMessage = "Phone field is required.")]
    public string ContactNumber { get; set; }
    public string NameCompany { get; set; }
    public string Status { get; set; }
}