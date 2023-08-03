namespace WebRecruitment.Application.Model.Response.AccountResponse;

public class ResponseAccountAdmin
{
    public ResponseAccountAdmin()
    {
        AdminId = Guid.Empty;
        AccountId = Guid.Empty;
        Username = string.Empty;
        Role = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Date = DateTime.MinValue;
        Status = string.Empty;
        HashPassword = string.Empty;
    }

    public ResponseAccountAdmin(Guid adminId, Guid accountId, string username, string hashPassword, string role,
        string firstName, string lastName, DateTime date, string status, string email, string phone, string address)
    {
        AdminId = adminId;
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

    public Guid AdminId { get; set; }
    public Guid AccountId { get; set; }
    public string Username { get; set; } = null!;
    public string HashPassword { get; set; } = null!;
    public string Role { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Status { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; }
    public string Address { get; set; }
}