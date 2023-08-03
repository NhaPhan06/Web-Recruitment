using System.ComponentModel.DataAnnotations;

namespace WebRecruitment.Application.Model.Request.AccountRequest;

public class RequestAccountToCompany
{
    public RequestAccountToCompany()
    {
    }

    public RequestAccountToCompany(string username, string hashPassword, string firstName, DateTime date,
        string lastName, string email, string address, string contactNumber, string nameCompany, string phone)
    {
        Username = username;
        HashPassword = hashPassword;
        FirstName = firstName;
        Date = date;
        LastName = lastName;
        Email = email;
        Address = address;
        ContactNumber = contactNumber;
        NameCompany = nameCompany;
        Phone = phone;
    }

    [Required(ErrorMessage = "The Username field is required.")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "The Password field is required.")]
    public string HashPassword { get; set; } = null!;

    [Required(ErrorMessage = "The First Name field is required.")]
    public string FirstName { get; set; } = null!;

    public DateTime Date { get; set; }

    [Required(ErrorMessage = "The Last Name field is required.")]
    public string LastName { get; set; } = null!;

    [EmailAddress] public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;
    [RegularExpression(@"^[0-9]{8,9}$", ErrorMessage = "The phone number must be an 8 or 9 digit integer.")]
    [Required(ErrorMessage = "Phone field is required.")]
    public string ContactNumber { get; set; }

    public string NameCompany { get; set; } = null!;

    //[Phone]
    [RegularExpression(@"^[0-9]{8,9}$", ErrorMessage = "The phone number must be an 8 or 9 digit integer.")]
    [Required(ErrorMessage = "Phone field is required.")]
    public string Phone { get; set; }
}