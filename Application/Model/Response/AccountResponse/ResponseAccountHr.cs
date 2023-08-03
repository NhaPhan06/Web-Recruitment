namespace WebRecruitment.Application.Model.Response.AccountResponse;

public class ResponseAccountHr
{
    public ResponseAccountHr()
    {
    }

    public ResponseAccountHr(Guid hrId, Guid accountId, Guid companyId, Guid positionId, string username,
        string hashPassword, string role, string firstName, string lastName, DateTime date, string status,
        string statusHr, string email, string phone, string address)
    {
        HrId = hrId;
        AccountId = accountId;
        CompanyId = companyId;
        PositionId = positionId;
        Username = username;
        HashPassword = hashPassword;
        Role = role;
        FirstName = firstName;
        LastName = lastName;
        Date = date;
        Status = status;
        StatusHr = statusHr;
        Email = email;
        Phone = phone;
        Address = address;
    }

    public Guid HrId { get; set; }
    public Guid AccountId { get; set; }
    public Guid CompanyId { get; set; }
    public Guid PositionId { get; set; }
    public string Username { get; set; } = null!;
    public string HashPassword { get; set; } = null!;
    public string Role { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Status { get; set; } = null!;
    public string StatusHr { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; }

    public string Address { get; set; }
}