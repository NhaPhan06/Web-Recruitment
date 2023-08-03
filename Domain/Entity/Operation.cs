using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity;

public class Operation
{
    public Operation()
    {
        Meetings = new HashSet<Meeting>();
    }

    public Guid OperationId { get; set; }

    public DateTime Date { get; set; }

    public string Status { get; set; } = null!;

    public Guid? CvId { get; set; }

    public Guid PostId { get; set; }

    public Guid CompanyId { get; set; }

    public Guid HrId { get; set; }

    [JsonInclude] public virtual Company Company { get; set; } = null!;

    [JsonInclude] public virtual Cv? Cv { get; set; }

    [JsonInclude] public virtual Hr Hr { get; set; } = null!;

    [JsonInclude] public virtual Post Post { get; set; } = null!;

    [JsonIgnore] public virtual ICollection<Meeting> Meetings { get; set; }
}