using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity;

public class Position
{
    public Position()
    {
        Hrs = new HashSet<Hr>();
        Interviewers = new HashSet<Interviewer>();
    }

    public Guid PositionId { get; set; }
    public string NamePosition { get; set; } = null!;

    [JsonInclude] public virtual ICollection<Hr> Hrs { get; set; }

    [JsonInclude] public virtual ICollection<Interviewer> Interviewers { get; set; }
}