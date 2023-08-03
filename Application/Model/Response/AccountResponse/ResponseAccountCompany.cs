namespace WebRecruitment.Application.Model.Response.AccountResponse;

public class ResponseAccountCompany
{
    public ResponseAccountCompany()
    {
    }

    public ResponseAccountCompany(Guid accountId, Guid companyId, List<Guid> positionId, List<string> namePosition,
        string username, string hashPassword, string role, string firstName, string lastName, DateTime date,
        string status, string statusCompany, string phone, string address, string email, List<Guid> hrId,
        List<Guid> interviewerId, List<Guid> jobId, List<Guid> postId, List<Guid> operationId, List<Guid> meetingId)
    {
        AccountId = accountId;
        CompanyId = companyId;
        PositionId = positionId ?? throw new ArgumentNullException(nameof(positionId));
        NamePosition = namePosition ?? throw new ArgumentNullException(nameof(namePosition));
        Username = username ?? throw new ArgumentNullException(nameof(username));
        HashPassword = hashPassword ?? throw new ArgumentNullException(nameof(hashPassword));
        Role = role ?? throw new ArgumentNullException(nameof(role));
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Date = date;
        Status = status ?? throw new ArgumentNullException(nameof(status));
        StatusCompany = statusCompany ?? throw new ArgumentNullException(nameof(statusCompany));
        Phone = phone;
        Address = address ?? throw new ArgumentNullException(nameof(address));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        HrId = hrId ?? throw new ArgumentNullException(nameof(hrId));
        InterviewerId = interviewerId ?? throw new ArgumentNullException(nameof(interviewerId));
        JobId = jobId ?? throw new ArgumentNullException(nameof(jobId));
        PostId = postId ?? throw new ArgumentNullException(nameof(postId));
        OperationId = operationId ?? throw new ArgumentNullException(nameof(operationId));
        MeetingId = meetingId ?? throw new ArgumentNullException(nameof(meetingId));
    }

    public Guid AccountId { get; set; }
    public Guid CompanyId { get; set; }
    public List<Guid> PositionId { get; set; }

    public List<string> NamePosition { get; set; }

    public string Username { get; set; } = null!;
    public string HashPassword { get; set; } = null!;
    public string Role { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Status { get; set; } = null!;
    public string StatusCompany { get; set; } = null!;
    public string Phone { get; set; }
    public string Address { get; set; } = null!;
    public string Email { get; set; } = null!;

    public List<Guid> HrId { get; set; }
    public List<Guid> InterviewerId { get; set; }
    public List<Guid> JobId { get; set; }
    public List<Guid> PostId { get; set; }
    public List<Guid> OperationId { get; set; }
    public List<Guid> MeetingId { get; set; }
}