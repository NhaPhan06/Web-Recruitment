namespace WebRecruitment.Application.Model.Request.MeetRequest;

public class MeetingRequest
{
    public string LinkMeet { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public Guid OperationId { get; set; }

    public Guid InterviewerId { get; set; }

    public Guid HrId { get; set; }
}