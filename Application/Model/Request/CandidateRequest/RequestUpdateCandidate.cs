using System.ComponentModel.DataAnnotations;

namespace Application.Model.Request.CandidateRequest
{
    public class RequestUpdateCandidate
    {
        public RequestUpdateCandidate()
        {
        }
        public RequestUpdateCandidate(string firstName, DateTime date,
        string lastName, string email, string phone, string address)
        {
            FirstName = firstName;
            Date = date;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        [Required(ErrorMessage = "The First Name field is required.")]
        public string FirstName { get; set; } = null!;

        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName { get; set; } = null!;

        [EmailAddress] public string Email { get; set; } = null!;
        [RegularExpression(@"^[0-9]{8,9}$", ErrorMessage = "The phone number must be an 8 or 9 digit integer.")]
        [Required(ErrorMessage = "Phone field is required.")]
        public string Phone { get; set; }

        public string Address { get; set; } = null!;

    }
}
