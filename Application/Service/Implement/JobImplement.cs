using AutoMapper;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Application.Model.Request.JobRequest;
using WebRecruitment.Application.Model.Response.JobResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums.Status;

namespace Application.Service.Implement;

public class JobImplement : JobService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public JobImplement(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseJobCompany> CreateJob(RequestJobCompany requestJobCompany)
    {
        var job = _mapper.Map<Job>(requestJobCompany);

        //set
        job.Status = JobEnum.ACCEPT.ToString();

        _unitOfWork.Job.Add(job);
        _unitOfWork.Save();
        return _mapper.Map<ResponseJobCompany>(job);
    }
}