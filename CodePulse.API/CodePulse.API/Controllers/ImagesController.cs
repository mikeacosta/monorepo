using CodePulse.API.Entities;
using CodePulse.API.Models;
using CodePulse.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers;

[ApiController]
[Route("api/images")]
public class ImagesController : ControllerBase
{
    private readonly IImagesRespository _imagesRespository;
    
    public ImagesController(IImagesRespository imagesRespository)
    {
        _imagesRespository = imagesRespository;
    }
    
    // POST: /api/images
    [HttpPost]
    public async Task<IActionResult> CreateImage([FromForm] IFormFile file, 
        [FromForm] string fileName,
        [FromForm] string title)
    {
        ValidateFileUpload(file);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var blogImage = new BlogImage
        {
            FileExtension = Path.GetExtension(file.FileName).ToLower(),
            FileName = fileName,
            Title = title,
            DateCreated = DateTime.Now
        };

        blogImage = await _imagesRespository.Upload(file, blogImage);

        var dto = new BlogImageDto
        {
            Id = blogImage.Id,
            FileName = blogImage.FileName,
            FileExtension = blogImage.FileExtension,
            Title = blogImage.Title,
            DateCreated = blogImage.DateCreated
        };

        return Created(String.Empty, dto);
    }

    private void ValidateFileUpload(IFormFile file)
    {
        var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
        var ext = Path.GetExtension(file.FileName).ToLower();
        
        if (!allowedExtensions.Contains(ext))
            ModelState.AddModelError("file", "Unsupported file format");
        
        if (file.Length > 10485760)
            ModelState.AddModelError("file", "File size too large (max 10MB)");
    }
}