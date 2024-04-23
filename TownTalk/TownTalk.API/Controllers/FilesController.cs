using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace TownTalk.API.Controllers;

[ApiController]
[Route("api/files")]
public class FilesController : ControllerBase
{
    private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
    
    public FilesController(FileExtensionContentTypeProvider provider)
    {
        _fileExtensionContentTypeProvider = provider
            ?? throw new ArgumentNullException(nameof(provider));
    }
    
    [HttpGet("{fileId}")]
    public ActionResult GetFile(string fileId)
    {
        var pathToFile = "Ramp-Up_Guide_Serverless.pdf";

        if (!System.IO.File.Exists(pathToFile))
            return NotFound();

        if (!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            contentType = "application/octet-stream";
        
        var bytes = System.IO.File.ReadAllBytes(pathToFile);
        return File(bytes, contentType, Path.GetFileName(pathToFile));
    }

    [HttpPost]
    public async Task<ActionResult> CreateFile(IFormFile file)
    {
        if (file.Length == 0 || file.Length > 20971520 || file.ContentType != "application/pdf")
            return BadRequest("No file or an invalid format has been input");

        var path = Path.Combine(Directory.GetCurrentDirectory(), $"uploaded_file_{Guid.NewGuid()}.pdf");

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok("File uploaded successful");
    }
}