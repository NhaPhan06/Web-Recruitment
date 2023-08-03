using WebRecruitment.Application.Model.Request.JobRequest;
using WebRecruitment.Application.Model.Response.JobResponse;

namespace Application.Service;

public interface JobService
{
    Task<ResponseJobCompany> CreateJob(RequestJobCompany requestJobCompany);
}