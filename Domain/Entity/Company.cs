using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity;

public class Company
{
    public Company()
    {
        Events = new HashSet<Event>();
        Hrs = new HashSet<Hr>();
        Interviewers = new HashSet<Interviewer>();
        Jobs = new HashSet<Job>();
        Operations = new HashSet<Operation>();
        Positions = new HashSet<Position>();
        Posts = new HashSet<Post>();
    }

    public Guid CompanyId { get; set; }

    /// <summary>

    public string? Description { get; set; } = null!;

    public int? Size { get; set; }

    public DateTime? FoundingYear { get; set; }

    public string? Logo { get; set; }

    public string? Benefits { get; set; }

    public string? Industry { get; set; }

    public string? Website { get; set; }

    /// </summary>

    public string ContactNumber { get; set; }

    public string NameCompany { get; set; } = null!;
    public string Status { get; set; } = null!;
    public Guid? Accountid { get; set; }

    [JsonInclude] public virtual Account? Account { get; set; }

    [JsonIgnore] public virtual ICollection<Event> Events { get; set; }

    [JsonIgnore] public virtual ICollection<Hr> Hrs { get; set; }

    [JsonIgnore] public virtual ICollection<Interviewer> Interviewers { get; set; }

    [JsonIgnore] public virtual ICollection<Job> Jobs { get; set; }

    [JsonIgnore] public virtual ICollection<Operation> Operations { get; set; }

    [JsonIgnore] public virtual ICollection<Position> Positions { get; set; }

    [JsonIgnore] public virtual ICollection<Post> Posts { get; set; }
}