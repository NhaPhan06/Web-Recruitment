using Application.Model.Request.CandidateRequest;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.OperationResponse;

namespace Application.Service;

public interface CandidateService
{
    Task<List<ResponseOperation>> GetOperationByStatus(string status);
    Task <List<ResponseAccountCandidate>> GetAllCandidatesAccount();
    Task<ResponseAccountCandidate> UpdateCandidateInfor(Guid id, RequestUpdateCandidate updateRequest);
}