using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Request.AccountRequest
{
    public class RequestUpdateAccount
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [RegularExpression(@"^[0-9]{8,9}$", ErrorMessage = "The phone number must be an 8 or 9 digit integer.")]
        [Required(ErrorMessage = "Phone field is required.")]
        public string Phone { get; set; }

        // Description your user
        public string Bio { get; set; } = null!;
        public string? Language { get; set; }
        public string? Nationality { get; set; }
        public string? Address { get; set; }
    }
}
