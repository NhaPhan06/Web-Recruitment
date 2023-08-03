using AutoMapper;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Application.Model.Request.PostRequest;
using WebRecruitment.Application.Model.Response.PostResponse;
using WebRecruitment.Application.Model.Update;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums.Status;

namespace Application.Service.Implement;

public class PostImplement : PostService
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    private readonly IJobRepository _jobRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PostImplement(IPostRepository postRepository, IUnitOfWork unitOfWork, IMapper mapper,
        IJobRepository jobRepository
        , ICompanyRepository companyRepository)
    {
        _postRepository = postRepository;
        _jobRepository = jobRepository;
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponsePostCompany> CreatePost(RequestCreatePost post)
    {
        var createPost = _mapper.Map<Post>(post);
        var postStatus = PostEnum.REQUESTCOMPANY.ToString();
        createPost.Status = postStatus;
        var requestHr = _unitOfWork.Hr.GetById(createPost.HrId);
        if (requestHr is null)
        {
            throw new Exception("Hr Id not exist");
        }
        createPost.HrId = requestHr.HrId;
        createPost.CompanyId = requestHr.CompanyId;
        var requestJob = _unitOfWork.Job.GetById(createPost.JobId);
        if (requestJob is null)
        {
            throw new Exception("Job Id not exist");
        }
        createPost.JobId = requestJob.JobId;
        _unitOfWork.Post.Add(createPost);
        _unitOfWork.Save();
        var responsePost = _mapper.Map<ResponsePostCompany>(createPost);
        var responseCompany = _unitOfWork.Company.GetById(responsePost.CompanyId);
        if (responseCompany is null)
        {
            throw new Exception("Company Id not exist");
        }
        responsePost.NameCompany = responseCompany.NameCompany;
        return responsePost;
    }


    public async Task DeletePost(Guid postId)
    {
        var post = _unitOfWork.Post.GetById(postId);
        if (post is null)
        {
            throw new Exception("Post is not exist");
        }

        post.Status = PostEnum.INACTIVE.ToString();
        _unitOfWork.Post.Update(post);
        _unitOfWork.Save();
    }

    public async Task<List<ResponsePostCompany>> GetAllPost()
    {
        var post = await _unitOfWork.Post.GetAllPost();
        if (post is null)
        {
            throw new Exception("Data does not exist");
        }

        return _mapper.Map<List<ResponsePostCompany>>(post);
    }

    public async Task<ResponsePostCompany> GetPostDetail(Guid id)
    {
        var postDetail = await _postRepository.GetAllPostDetail(id);
        if (postDetail is null)
            if (postDetail is null)
            {
                throw new Exception("Can not found by" + id);
            }

        return _mapper.Map<ResponsePostCompany>(postDetail);
    }

    public async Task<List<ResponsePostCompany>> GetPostLocation(string location, string nameSkill)
    {
        var postLocation = await _postRepository.GetPostByLocation(location, nameSkill);
        return _mapper.Map<List<ResponsePostCompany>>(postLocation);
    }

    public async Task<List<ResponsePostCompany>> GetPostCompanyName(string nameCompany)
    {
        var company = await _companyRepository.GetCompanyByName(nameCompany);
        var postNameCompany = await _postRepository.GetPostByCompanyID(company);
        return _mapper.Map<List<ResponsePostCompany>>(postNameCompany);
    }

    public async Task<List<ResponsePostCompany>> GetPostNameSkill(string nameSkill)
    {
        var job = await _jobRepository.GetJobByNameSkill(nameSkill);
        var postNameSkill = await _postRepository.GetPostByNameSkill(job);
        return _mapper.Map<List<ResponsePostCompany>>(postNameSkill);
    }

    public async Task<List<ResponsePostCompany>> GetPostSalary(double salary, string nameSkill)
    {
        var postSalary = _postRepository.GetPostBySalary(salary, nameSkill);
        return _mapper.Map<List<ResponsePostCompany>>(postSalary);
    }

    public async Task<ResponsePostCompany> UpdatePost(Guid postId, UpdatePostModel updatePostModel)
    {
        var post = _unitOfWork.Post.GetById(postId);
        if (post is null)
        {
            throw new Exception("Post is not exist");
        }
        var updatePost = _mapper.Map(updatePostModel, post);
        _unitOfWork.Post.Update(updatePost);
        _unitOfWork.Save();
        var responseUpdatedPost = _mapper.Map<ResponsePostCompany>(updatePost);
        var job = _unitOfWork.Job.GetById(post.JobId);
        if (job is null)
        {
            throw new Exception("Job is not exist");
        }
        responseUpdatedPost.NameSkill = job.NameSkill;
        responseUpdatedPost.Description = job.Description;
        var hr = _unitOfWork.Hr.GetById(post.HrId);
        if (hr is null)
        {
            throw new Exception("Hr is not exist");
        }
        responseUpdatedPost.hrName = hr.NameHr;
        var company = _unitOfWork.Company.GetById(post.CompanyId);
        if (company is null)
        {
            throw new Exception("Company is not exist");
        }
        responseUpdatedPost.NameCompany = company.NameCompany;
        return responseUpdatedPost;
    }

}