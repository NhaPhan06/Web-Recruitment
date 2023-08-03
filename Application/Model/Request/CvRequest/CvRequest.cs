using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebRecruitment.Application.Model.Request.CvRequest;

public class CvRequest
{
    [Required] public Guid? CandidateId { get; set; }

    [Required] public string Title { get; set; } = null!;

    [Required] public string Description { get; set; } = null!;

    [Required] public IFormFile UrlFile { get; set; } = null!;
}