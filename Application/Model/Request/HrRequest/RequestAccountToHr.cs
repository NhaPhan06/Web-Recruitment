using System.ComponentModel.DataAnnotations;
using WebRecruitment.Domain.Enums.Status;

namespace WebRecruitment.Application.Model.Request.HrRequest;

public class RequestAccountToHr
{
    public RequestAccountToHr()
    {
    }

    public RequestAccountToHr(Guid? positionId, string username, string hashPassword, string firstName, DateTime date,
        string lastName, string email, string nameHr, Guid? companyId, string phone, string gender)
    {
        PositionId = positionId;
        Username = username;
        HashPassword = hashPassword;
        FirstName = firstName;
        Date = date;
        LastName = lastName;
        Email = email;
        NameHr = nameHr;
        CompanyId = companyId;
        Phone = phone;
        Gender = gender;
    }

    [Required(ErrorMessage = "The PositionId field is required.")]
    public Guid? PositionId { get; set; }

    [Required(ErrorMessage = "The CompanyId field is required.")]
    public Guid? CompanyId { get; set; }

    [Required(ErrorMessage = "The Username field is required.")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "The HashPassword field is required.")]
    public string HashPassword { get; set; } = null!;

    [Required(ErrorMessage = "The First Name field is required.")]
    public string FirstName { get; set; } = null!;

    public DateTime Date { get; set; }

    [Required(ErrorMessage = "The Last Name field is required.")]
    
    
    public string LastName { get; set; } = null!;
    [RegularExpression(@"^[0-9]{8,9}$", ErrorMessage = "The phone number must be an 8 or 9 digit integer.")]
    [Required(ErrorMessage = "Phone field is required.")]
    public string Phone { get; set; }
    [EmailAddress] public string Email { get; set; } = null!;

    [RegularExpression("^(male|female)$", ErrorMessage = "The field must be either 'male' or 'female'.")]
    public string Gender { get; set; } = null!;
    public string NameHr { get; set; } = null!;
}