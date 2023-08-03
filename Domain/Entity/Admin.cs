using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity;

public class Admin
{
    public Guid AdminId { get; set; }
    public Guid Accountid { get; set; }

    [JsonInclude] public virtual Account Account { get; set; } = null!;
}