using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity;

public class Candidate
{
    public Candidate()
    {
        Cvs = new HashSet<Cv>();
        Events = new HashSet<Event>();
    }

    public Guid CandidateId { get; set; }
    public Guid Accountid { get; set; }

    [JsonInclude] public virtual Account Account { get; set; } = null!;

    [JsonIgnore] public virtual ICollection<Cv> Cvs { get; set; }

    [JsonIgnore] public virtual ICollection<Event> Events { get; set; }
}