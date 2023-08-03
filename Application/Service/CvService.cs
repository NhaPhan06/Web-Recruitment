using WebRecruitment.Application.Model.Request.CvRequest;
using WebRecruitment.Application.Model.Response.CvResponse;

namespace Application.Service;

public interface CVService
{
    Task Upload(Guid id, string fileExtension, CvRequest cvModel);
    Task<Stream> Download(Guid cvId);
    Task<ResponsePostCv> GetCVDetail(Guid id);
}