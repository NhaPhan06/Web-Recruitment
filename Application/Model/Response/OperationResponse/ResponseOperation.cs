using WebRecruitment.Application.Model.Response.CvResponse;
using WebRecruitment.Application.Model.Response.PostResponse;

namespace WebRecruitment.Application.Model.Response.OperationResponse;

public class ResponseOperation
{
    public ResponseOperation()
    {
    }

    public ResponseOperation(Guid operationId, DateTime date, string status, ResponsePostCv responseCv,
        ResponsePostCompany responsePostCompany)
    {
        OperationId = operationId;
        Date = date;
        Status = status;
        this.responseCv = responseCv;
        this.responsePostCompany = responsePostCompany;
    }

    public Guid OperationId { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; } = null!;
    public ResponsePostCv responseCv { get; set; }
    public ResponsePostCompany responsePostCompany { get; set; }
}