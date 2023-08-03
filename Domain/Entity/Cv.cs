using System.Text.Json.Serialization;

namespace WebRecruitment.Domain.Entity;

public class Cv
{
    public Cv()
    {
        Operations = new HashSet<Operation>();
    }

    public Guid CvId { get; set; }

    /// <summary>

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public string UrlFile { get; set; } = null!;

    /// </summary>

    public string Status { get; set; } = null!;

    public Guid? CandidateId { get; set; }

    [JsonInclude] public virtual Candidate? Candidate { get; set; }

    [JsonIgnore] public virtual ICollection<Operation> Operations { get; set; }
}