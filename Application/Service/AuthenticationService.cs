using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Model.Request.InterviewerRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;

namespace Application.Service;

public interface AuthenticationService
{
    Task<LoginRespone> Validate(RequestLogin accountLogin);
    Task<Boolean> Logout(Guid AccountId);
    Task<ResponseAccountAdmin> CreateAccountAdmin(RequestAccountToAdmin requestAccountToAdmin);
    Task<ResponseAccountCandidate> CreateAccountCandidate(RequestAccountToCadidate requestAccountToCandidate);
    Task<ResponseAccountCompany> CreateAccountCompany(RequestAccountToCompany requestAccountToCompany);
    Task<ResponseAccountHr> CreateAccountHr(RequestAccountToHr requestAccountToHr);
    Task<ResponseAccountInterviewer> CreateAccountInterviewer(RequestAccountToInterviewer requestAccountToInterviewer);
    Task<bool> ForgetPassword(string email);
    Task<bool> ResetPassword(string email, string password, string resetToken);

}