namespace WebRecruitment.Application.Model.Response.CompanyResponse;

public class ResponseOfCompany
{
    public Guid AccountId { get; set; }
    public Guid CompanyId { get; set; }
    public string NameCompany { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public DateTime Birthday { get; set; }
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string ContactNumber { get; set; }
    public string Description { get; set; } = null!;
    public int Size { get; set; }
    public DateTime FoundingYear { get; set; }
    public string Logo { get; set; }
    public string Benefits { get; set; }
    public string Industry { get; set; }
    public string Website { get; set; }
    public string Status { get; set; } = null!;
}