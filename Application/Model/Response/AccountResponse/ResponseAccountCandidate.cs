namespace WebRecruitment.Application.Model.Response.AccountResponse;

public class ResponseAccountCandidate
{
    public ResponseAccountCandidate()
    {
        CandidateId = Guid.Empty;
        AccountId = Guid.Empty;
        Username = string.Empty;
        Role = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Date = DateTime.MinValue;
        Status = string.Empty;
        HashPassword = string.Empty;
    }

    public ResponseAccountCandidate(Guid candidateId, Guid accountId, List<Guid> cvId, string username,
        string hashPassword, string role, string firstName, string lastName, DateTime date, string status, string email,
        string phone, string address)
    {
        CandidateId = candidateId;
        AccountId = accountId;
        CvId = cvId;
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

    public Guid CandidateId { get; set; }

    public Guid AccountId { get; set; }

    //[JsonIgnore]
    public List<Guid> CvId { get; set; }
    //[JsonIgnore]

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