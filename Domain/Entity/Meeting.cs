using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity;

public class Meeting
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid MeetId { get; set; }

    public string LinkMeet { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public Guid OperationId { get; set; }

    public Guid InterviewerId { get; set; }

    public Guid HrId { get; set; }
    
    public string Status { get; set; }

    [JsonInclude] public virtual Hr Hr { get; set; } = null!;

    [JsonInclude] public virtual Interviewer Interviewer { get; set; } = null!;

    [JsonInclude] public virtual Operation Operation { get; set; } = null!;
}