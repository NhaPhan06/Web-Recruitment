using Application.Model.Request.InterviewerRequest;
using AutoMapper;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Application.Model.Request.OperationRequest;
using WebRecruitment.Application.Model.Response.OperationResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums.Status;

namespace Application.Service.Implement;

public class OperationImplement : OperationService
{
    private readonly IMapper _mapper;
    private readonly IOperationRepository _operationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OperationImplement(IOperationRepository operationRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _operationRepository = operationRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseOperation> HrCheck(Guid id)
    {
        var operation = _unitOfWork.Operation.GetById(id);
        bool check = operation.Status == OperationEnum.WAITING.ToString();
        if (check)
        {
            operation.Status = OperationEnum.CHECK.ToString();
        }
        _unitOfWork.Operation.Update(operation);
        _unitOfWork.Save();
        return _mapper.Map<ResponseOperation>(operation);
    }

    
    public async Task<ResponseOperation> CreateApplyJob(RequestCreateOperation operation)
    {
        var applyJob = _mapper.Map<Operation>(operation);
        var operationStatus = OperationEnum.WAITING.ToString();
        applyJob.Status = operationStatus;
        var post = _unitOfWork.Post.GetById(applyJob.PostId);
        if (post is null)
        {
            throw new Exception("Post not found");
        }
        applyJob.CompanyId = post.CompanyId;
        var cv = _unitOfWork.Cv.GetById(applyJob.CvId);
        if (cv is null)
        {
            throw new Exception("Cv not found");
        }
        applyJob.CvId = cv.CvId;
        var hr = _unitOfWork.Hr.GetById(applyJob.HrId);
        if (hr is null)
        {
            throw new Exception("Hr not found");
        }
        applyJob.HrId = hr.HrId;
        _unitOfWork.Operation.Add(applyJob);
        _unitOfWork.Save();
        var responseApply = _mapper.Map<ResponseOperation>(applyJob);
        var responseCompany = _unitOfWork.Company.GetById(applyJob.CompanyId);
        if (responseCompany is null)
        {
            throw new Exception("Company not found");
        }
        var responseJob = _unitOfWork.Job.GetById(post.JobId);
        responseApply.responsePostCompany.NameCompany = responseCompany.NameCompany;
        responseApply.responsePostCompany.NameSkill = responseJob.NameSkill;
        responseApply.responsePostCompany.Description = responseJob.Description;
        return responseApply;
    }

    

    public async Task<ResponseOperation> GetStatusOperation(Guid id)
    {
        var operation = _unitOfWork.Operation.GetStatus(id);
        if (operation is null)
        {
            throw new Exception("The operation does not exist");
        }
        return _mapper.Map<ResponseOperation>(operation);
    }

    public async Task<ResponseOperation> IntervieweCheck(Guid operationId, bool check)
    {
        var operation = _unitOfWork.Operation.GetById(operationId);
        if (check is true)
        {
            operation.Status = OperationEnum.APPROVE.ToString();
        }
        else
        {
            operation.Status = OperationEnum.REJECT.ToString();
        }
        _unitOfWork.Operation.Update(operation);
        _unitOfWork.Save();
        return _mapper.Map<ResponseOperation>(operation);
    }

    public async Task<List<ResponseOperation>> GetAllApplyByPostId(Guid id)
    {
        var operations = await _unitOfWork.Operation.GetByPostId(id);
        if (operations is null)
        {
            throw new Exception("This post does not exist in any operation");
        }
        var responseOperation= _mapper.Map<List<ResponseOperation>>(operations);
        return responseOperation;
    }
}
