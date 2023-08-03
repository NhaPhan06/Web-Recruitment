using Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.Model.Request.CvRequest;
using WebRecruitment.Application.Model.Response.CvResponse;
using WebRecruitment.Infrastructures.Repository;

namespace WebApi.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CVController : ControllerBase
    {
        private readonly CVService _cvService;
        public CVController(CVService cvService)
        {
            _cvService = cvService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] CvRequest file)
        {
            try
            {
                var id = Guid.NewGuid();
                var fileExtension = Path.GetExtension(file.UrlFile.FileName);
                await _cvService.Upload(id,fileExtension, file);
                return Ok("File uploaded successfully with CV ID: " + id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while uploading CV: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Download(Guid cvId)
        {
            try
            {
                var cv = await _cvService.GetCVDetail(cvId);
                if (cv is null)
                {
                    // Check if CV is null
                    return NotFound();
                }

                // Extract the file extension from the URL or file path
                string fileExtension = Path.GetExtension(cv.UrlFile)?.TrimStart('.');
                string contentType = GetContentType(fileExtension);
                if (contentType is null)
                {
                    return BadRequest($"Invalid file extension: {fileExtension}"); // Handle unsupported file types
                }

                var cvStream = await _cvService.Download(cvId);
                return File(cvStream, contentType, $"{cvId}.{fileExtension}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred while downloading CV: {ex.Message}");
            }
        }


        private string GetContentType(string fileExtension)
        {
            if (string.IsNullOrEmpty(fileExtension))
            {
                return null;
            }

            fileExtension = fileExtension.TrimStart('.');

            switch (fileExtension.ToLower())
            {
                case "pdf":
                    return "application/pdf";
                case "jpg":
                    return "image/jpg";
                case "jpeg":
                    return "image/jpeg";
                case "png":
                    return "image/png";
                // Add more cases for other supported file types
                default:
                    return null; // Return null for unsupported file types
            }
        }

        [HttpGet]
        public async Task<ActionResult<ResponsePostCv>> CvDetail(Guid id)
        {
            var cv = await _cvService.GetCVDetail(id);
            return cv == null ? NotFound() : Ok(cv);
        }
    }
}