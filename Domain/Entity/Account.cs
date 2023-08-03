using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity;

public class Account
{
    public Account()
    {
        Admins = new HashSet<Admin>();
        Candidates = new HashSet<Candidate>();
        Companies = new HashSet<Company>();
        Hrs = new HashSet<Hr>();
        Interviewers = new HashSet<Interviewer>();
    }

    public Guid Accountid { get; set; }
    public string FirstName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string HashPassword { get; set; } = null!;
    public DateTime Birthday { get; set; }
    public string Status { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Email { get; set; } = null!;

    /// <summary>
    public string? Image { get; set; }

    public string Phone { get; set; }

    public string? Gender { get; set; } = null!;

    // Description your user
    public string Bio { get; set; } = null!;
    public string? Language { get; set; }
    public string? Nationality { get; set; }
    public string? Address { get; set; }

    /// </summary>
    [JsonIgnore]
    public virtual ICollection<Admin> Admins { get; set; }

    [JsonIgnore] public virtual ICollection<Candidate> Candidates { get; set; }

    [JsonIgnore] public virtual ICollection<Company> Companies { get; set; }

    [JsonIgnore] public virtual ICollection<Hr> Hrs { get; set; }

    [JsonIgnore] public virtual ICollection<Interviewer> Interviewers { get; set; }
}