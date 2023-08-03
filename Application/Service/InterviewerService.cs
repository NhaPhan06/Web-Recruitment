using Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;

namespace Application.Service;

public interface InterviewerService
{
    Task<ResponseAccountInterviewer> SetStatusInterviewer(Guid id);
    Task<List<ResponseAccountInterviewer>> GetAllInterviewers();
    Task<ResponseAccountInterviewer> GetInterviewerById(Guid id);
    Task<List<ResponseAccountInterviewer>> GetInterviewerByName(string name);
    Task<ResponseAccountInterviewer> UpdateInterInfor(Guid interviewerId, RequestUpdateAccount requestUpdateAccount);
}