using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity;

public class Event
{
    public Guid EventId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime StartEvent { get; set; }

    public DateTime EndEvent { get; set; }

    public string Description { get; set; } = null!;

    public string Img { get; set; } = null!;

    public Guid CompanyId { get; set; }

    public Guid CandidateId { get; set; }

    [JsonInclude] public virtual Candidate Candidate { get; set; } = null!;

    [JsonInclude] public virtual Company Company { get; set; } = null!;
}