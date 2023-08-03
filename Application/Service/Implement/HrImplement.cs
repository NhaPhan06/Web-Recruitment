using Application.Model.Request.AccountRequest;
using AutoMapper;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums.Status;

namespace Application.Service.Implement;

public class HrImplement : HrService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public HrImplement(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseAccountHr> Delete(Guid id)
    {
        try
        {
            var response = await _unitOfWork.Hr.DeleteHr(id);
            response.Status = HrEnum.INACTIVE.ToString();
            _unitOfWork.Save();
            return _mapper.Map<ResponseAccountHr>(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<ResponseAccountHr>> GetALLHr()
    {
        try
        {
            var repsonse = await _unitOfWork.Hr.GetAllHr();
            return _mapper.Map<List<ResponseAccountHr>>(repsonse);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<ResponseAccountHr> UpdateHrInfor(Guid hrId, RequestUpdateAccount requestUpdateAccount)
    {
        var checkIdHr = _unitOfWork.Hr.GetById(hrId);
        if (checkIdHr == null)
        {
            throw new Exception("HR ID Null");
        }
        var checkAccountId=_unitOfWork.Account.GetById(checkIdHr.Accountid);
        if(checkAccountId == null)
        {
            throw new Exception("Account ID Null");
        }
        var account = _mapper.Map(requestUpdateAccount, checkAccountId);
        _unitOfWork.Account.Update(account);
        _unitOfWork.Save();
        return _mapper.Map<ResponseAccountHr>(account);
    }
}