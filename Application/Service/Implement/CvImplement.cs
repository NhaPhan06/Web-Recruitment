using Azure.Storage.Blobs;
using WebRecruitment.Application.Model.Request.CvRequest;
using AutoMapper;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Application.Model.Response.CvResponse;
using Domain.Exceptions;

namespace Application.Service.Implement;

public class CVImplement : CVService
{

    private readonly BlobServiceClient _blobServiceClient;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CVImplement(BlobServiceClient blobServiceClient, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _blobServiceClient = blobServiceClient;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Upload(Guid id, string fileExtension, CvRequest cvModel)
    {
        var containerInstance = _blobServiceClient.GetBlobContainerClient("recruitmentwebapi");
        var blobInstace = containerInstance.GetBlobClient(id.ToString() + fileExtension);
        await blobInstace.UploadAsync(cvModel.UrlFile.OpenReadStream());

        var cv = _mapper.Map<Cv>(cvModel);
        cv.CvId = id;
        cv.UrlFile = blobInstace.Uri.AbsoluteUri;
        cv.Status = "ACTIVE";
        cv.CreationDate = DateTime.Now.AddHours(DateTime.Now.Hour);

        // ADD NEW TO DB
        _unitOfWork.Cv.Add(cv);

        //SAVE CHANGE
        _unitOfWork.Save();
    }

    public async Task<Stream> Download(Guid cvId)
    {
        var containerInstance = _blobServiceClient.GetBlobContainerClient("recruitmentwebapi");
        var cv = _unitOfWork.Cv.GetById(cvId);

        if (cv is null)
        {
            throw new NotFoundException("CV not found");
        }
        string fileExtension = Path.GetExtension(cv.UrlFile);
        var blobInstance = containerInstance.GetBlobClient(cv.CvId.ToString() + fileExtension);
        var downloadContent = await blobInstance.DownloadAsync();
        return downloadContent.Value.Content;
    }

    public async Task<ResponsePostCv> GetCVDetail(Guid id)
    {
        var postCv = _unitOfWork.Cv.GetById(id);
        return _mapper.Map<ResponsePostCv>(postCv);
    }



}