using Application.Model.Request.AccountRequest;
using AutoMapper;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums.Status;

namespace Application.Service.Implement;

public class InterviewerImplement : InterviewerService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public InterviewerImplement(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ResponseAccountInterviewer>> GetAllInterviewers()
    {
        var interviewer = await _unitOfWork.Interviewer.GetAllInterviewers();
        if (interviewer is null)
        {
            throw new Exception("The interviewer list is empty");
        }
        return _mapper.Map<List<ResponseAccountInterviewer>>(interviewer);
    }

    public async Task<ResponseAccountInterviewer> GetInterviewerById(Guid id)
    {
        var interviewer = await _unitOfWork.Interviewer.GetInterviewerById(id);
        if (interviewer is null)
        {
            throw new Exception("The interviewer does not exist");
        }
        return _mapper.Map<ResponseAccountInterviewer>(interviewer);
    }

    public async Task<List<ResponseAccountInterviewer>> GetInterviewerByName(string name)
    {
        var interviewer = await _unitOfWork.Interviewer.GetInterviewerByName(name);
        if (interviewer is null)
        {
            throw new Exception("Can not find interviewer named " + name);
        }
        return _mapper.Map<List<ResponseAccountInterviewer>>(interviewer);
    }

    public async Task<ResponseAccountInterviewer> SetStatusInterviewer(Guid id)
    {
        var interviewer = await _unitOfWork.Interviewer.GetInterviewerById(id);
        if (interviewer is null)
        {
            throw new Exception("The interviewer does not exist");
        }
        interviewer.Status = InterviewerEnum.INACTIVE.ToString();
        _unitOfWork.Save();
        return _mapper.Map<ResponseAccountInterviewer>(interviewer);
    }

    public async Task<ResponseAccountInterviewer> UpdateInterInfor(Guid interviewerId, RequestUpdateAccount requestUpdateAccount)
    {
        var checkIdHr = _unitOfWork.Interviewer.GetById(interviewerId);
        if (checkIdHr == null)
        {
            throw new Exception("HR ID Null");
        }
        var checkAccountId = _unitOfWork.Account.GetById(checkIdHr.Accountid);
        if (checkAccountId == null)
        {
            throw new Exception("Account ID Null");
        }
        var account = _mapper.Map(requestUpdateAccount, checkAccountId);
        _unitOfWork.Account.Update(account);
        _unitOfWork.Save();
        return _mapper.Map<ResponseAccountInterviewer>(account);
    }
}