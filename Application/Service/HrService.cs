using Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;

namespace Application.Service;

public interface HrService
{
    public Task<List<ResponseAccountHr>> GetALLHr();
    public Task<ResponseAccountHr> Delete(Guid id);
    public Task<ResponseAccountHr> UpdateHrInfor(Guid hrId, RequestUpdateAccount requestUpdateAccount);

}