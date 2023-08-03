namespace WebRecruitment.Application.Model.Response.CvResponse;

public class ResponsePostCv
{
    public ResponsePostCv(Guid candidateId, Guid cvId, string? urlFile, string title, string description,
        DateTime creationDate, string status)
    {
        CandidateId = candidateId;
        CvId = cvId;
        UrlFile = urlFile;
        Title = title;
        Description = description;
        CreationDate = creationDate;
        Status = status;
    }

    public Guid CandidateId { get; set; }
    public Guid CvId { get; set; }
    public string? UrlFile { get; set; }
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreationDate { get; set; }
    public string Status { get; set; } = null!;
}