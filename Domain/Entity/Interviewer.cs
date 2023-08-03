using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity;

public class Interviewer
{
    public Interviewer()
    {
        Meetings = new HashSet<Meeting>();
    }


    public Guid InterviewerId { get; set; }

    public string NameInterviewer { get; set; } = null!;

    public string Status { get; set; } = null!;

    public Guid? PositionId { get; set; }

    public Guid Accountid { get; set; }

    public Guid CompanyId { get; set; }

    [JsonInclude] public virtual Account Account { get; set; } = null!;

    [JsonInclude] public virtual Company Company { get; set; } = null!;

    [JsonInclude] public virtual Position? Position { get; set; }

    [JsonInclude] public virtual ICollection<Meeting> Meetings { get; set; }
}