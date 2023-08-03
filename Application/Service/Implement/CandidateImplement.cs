using Application.Model.Request.CandidateRequest;
using Application.Model.Response.MeetingResponse;
using AutoMapper;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Application.Model.Response.OperationResponse;
using WebRecruitment.Domain.Entity;

namespace Application.Service.Implement;

public class CandidateImplement : CandidateService
{
    private readonly IMapper _mapper;
    private readonly IOperationRepository _operation;
    private readonly IUnitOfWork _unitOfWork;

    public CandidateImplement(IOperationRepository operation, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _operation = operation;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ResponseOperation>> GetOperationByStatus(string status)
    {
        var operations = await _operation.GetOperationByStatus(status);
        return _mapper.Map<List<ResponseOperation>>(operations);
    }

    public async Task<List<ResponseAccountCandidate>> GetAllCandidatesAccount()
    {
        var candidates = _unitOfWork.Candidate.GetAll();
        if (candidates is null)
        {
            throw new Exception("Candidates list is empty");
        }

        var responseCandidates = _mapper.Map<List<ResponseAccountCandidate>>(candidates);

        // Populate the account-related attributes for each candidate
        foreach (var candidate in responseCandidates)
        {
            var account = _unitOfWork.Account.GetById(candidate.AccountId);

            if (account is not null)
            {
                candidate.FirstName = account.FirstName;
                candidate.LastName = account.LastName;
                candidate.Username = account.Username;
                candidate.Date = account.Birthday;
                candidate.Email = account.Email;
                candidate.Address = account.Address;
            }
        }

        return responseCandidates;
    }



    public async Task<ResponseAccountCandidate> UpdateCandidateInfor(Guid id, RequestUpdateCandidate updateRequest)
    {
        var candidate = _unitOfWork.Candidate.GetById(id);
        if (candidate is null)
        {
            throw new Exception("Candidate not found!");
        }
        var account = _unitOfWork.Account.GetById(candidate.Accountid);
        // Update the candidate account properties
        account.FirstName = updateRequest.FirstName;
        account.LastName = updateRequest.LastName;
        account.Email = updateRequest.Email;
        account.Address = updateRequest.Address;
        account.Phone = updateRequest.Phone;

        _unitOfWork.Account.Update(account);
        _unitOfWork.Save();

        return _mapper.Map<ResponseAccountCandidate>(candidate);
    }
}