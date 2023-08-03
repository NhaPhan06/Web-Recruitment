using Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Application.Model.Request.PostRequest;
using WebRecruitment.Application.Model.Response.PostResponse;
using WebRecruitment.Application.Model.Update;

namespace WebRecruitment.WebApi.Controllers;

//[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly PostService _postService;
    private readonly IUnitOfWork _unitOfWork;

    public PostController(PostService postService, IUnitOfWork unitOfWork)
    {
        _postService = postService;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<ResponsePostCompany>> ViewAllPost()
    {
        var posts = await _postService.GetAllPost();
        return posts == null ? NotFound() : Ok(posts);
    }

    [HttpGet]
    public async Task<ActionResult<ResponsePostCompany>> PostDetail(Guid id)
    {
        var posts = await _postService.GetPostDetail(id);
        return posts == null ? NotFound() : Ok(posts);
    }
     
    [HttpGet]
    public async Task<ActionResult<ResponsePostCompany>> PostByCompanyName(string nameCompany)
    {
        var post = await _postService.GetPostCompanyName(nameCompany);
        return post == null ? NotFound() : Ok(post);
    }
    [HttpGet]
    public async Task<ActionResult<ResponsePostCompany>> PostByNameSkill(string nameSkill)
    {
        var post = await _postService.GetPostNameSkill(nameSkill);
        return post == null ? NotFound() : Ok(post);
    }

    [HttpGet]
    public async Task<ActionResult<ResponsePostCompany>> PostByLocation(string location, string nameSkill)
    {
        var post = await _postService.GetPostLocation(location, nameSkill);
        return post == null ? NotFound() : Ok(post);
    }

    [HttpGet]
    public async Task<ActionResult<ResponsePostCompany>> PostBySalary(double salary, string nameSkill)
    {
        var post = await _postService.GetPostSalary(salary, nameSkill);
        return post == null ? NotFound() : Ok(post);
    }

    [HttpPost]
    public async Task<ActionResult<ResponsePostCompany>> CreatePost(RequestCreatePost post)
    {
        var createdPost = await _postService.CreatePost(post);
        return createdPost == null ? NotFound() : Ok(createdPost);
    }
    [HttpPut]
    public async Task<ActionResult<ResponsePostCompany>> UpdatePost(Guid postId, UpdatePostModel updatePostModel)
    {
        var updatedPost = await _postService.UpdatePost(postId, updatePostModel);
        return updatedPost == null ? NotFound() : Ok(updatedPost);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(Guid postId)
    {
        var deletedPost = _postService.DeletePost(postId);
        return deletedPost == null ? NoContent() : Ok(deletedPost);
    }
}