namespace WebRecruitment.Application.Model.Response.AccountResponse;

public class ResponseAllAccount
{
    public ResponseAllAccount()
    {
        AdminId = Guid.Empty;
        CandidateId = Guid.Empty;
        CompanyId = Guid.Empty;
        AccountId = Guid.Empty;
        Username = string.Empty;
        Role = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Date = DateTime.MinValue;
        Status = string.Empty;
        HashPassword = string.Empty;
    }

    public ResponseAllAccount(Guid? adminId, Guid candidateId, Guid companyId, Guid accountId, string username,
        string hashPassword, string role, string firstName, string lastName, DateTime date, string status, string email,
        string phone, string address)
    {
        AdminId = adminId;
        CandidateId = candidateId;
        CompanyId = companyId;
        AccountId = accountId;
        Username = username;
        HashPassword = hashPassword;
        Role = role;
        FirstName = firstName;
        LastName = lastName;
        Date = date;
        Status = status;
        Email = email;
        Phone = phone;
        Address = address;
    }

    public Guid? AdminId { get; set; }
    public Guid CandidateId { get; set; }
    public Guid CompanyId { get; set; }
    public Guid AccountId { get; set; }
    public string Username { get; set; }
    public string HashPassword { get; set; }
    public string Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public string Email { get; set; } = null!;
    public string Phone { get; set; }
    public string Address { get; set; }
}