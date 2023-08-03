using WebRecruitment.Application.Model.Request.PostRequest;
using WebRecruitment.Application.Model.Response.PostResponse;
using WebRecruitment.Application.Model.Update;

namespace Application.Service;

public interface PostService
{
    Task<List<ResponsePostCompany>> GetAllPost();
    Task<ResponsePostCompany> GetPostDetail(Guid id);
    Task<List<ResponsePostCompany>> GetPostLocation(string location,string nameSkill);
    Task<List<ResponsePostCompany>> GetPostCompanyName(string nameCompany);
    Task<List<ResponsePostCompany>> GetPostNameSkill(string nameSkill);
    Task<List<ResponsePostCompany>> GetPostSalary(double salary, string nameSkill);
    Task<ResponsePostCompany> CreatePost(RequestCreatePost post);
    Task DeletePost(Guid postId);
    Task<ResponsePostCompany> UpdatePost(Guid postId, UpdatePostModel updatePostModel);
}