using Application.Model.Request.InterviewerRequest;
using WebRecruitment.Application.Model.Request.OperationRequest;
using WebRecruitment.Application.Model.Response.OperationResponse;

namespace Application.Service;

public interface OperationService
{
    Task<ResponseOperation> CreateApplyJob(RequestCreateOperation requestCreateOperation);
    Task<ResponseOperation> GetStatusOperation(Guid id);
    Task<ResponseOperation> IntervieweCheck(Guid operationId, bool check);
    Task<ResponseOperation> HrCheck(Guid id);
    Task<List<ResponseOperation>> GetAllApplyByPostId(Guid id);
}