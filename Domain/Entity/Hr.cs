using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity;

public class Hr
{
    public Hr()
    {
        Meetings = new HashSet<Meeting>();
        Operations = new HashSet<Operation>();
        Posts = new HashSet<Post>();
    }

    public Guid HrId { get; set; }

    public string NameHr { get; set; } = null!;

    public string Status { get; set; } = null!;

    public Guid? PositionId { get; set; }

    public Guid Accountid { get; set; }

    public Guid CompanyId { get; set; }
    

    [JsonInclude] public virtual Account Account { get; set; } = null!;

    [JsonInclude] public virtual Company Company { get; set; } = null!;

    [JsonInclude] public virtual Position? Position { get; set; }

    [JsonIgnore] public virtual ICollection<Meeting> Meetings { get; set; }

    [JsonIgnore] public virtual ICollection<Operation> Operations { get; set; }

    [JsonIgnore] public virtual ICollection<Post> Posts { get; set; }
}