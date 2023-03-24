using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers;

[Route("api/files")]
[ApiController]
public class FilesController : ControllerBase
{
    private readonly FileExtensionContentTypeProvider _fileExtContentTypeProvider;

    public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
    {
        _fileExtContentTypeProvider = fileExtensionContentTypeProvider
                                            ?? throw new System.ArgumentNullException(nameof(fileExtensionContentTypeProvider));
    }
    [HttpGet("{fileId}")]
    public ActionResult GetFile(string fileId)
    {
        var pathToFile = "Web_API_Best_Practices.pdf";
        
        if (!System.IO.File.Exists(pathToFile)) 
            return NotFound();

        if (!_fileExtContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            contentType = "application/octet-stream";
        
        var bytes = System.IO.File.ReadAllBytes(pathToFile);
        return File(bytes, contentType, Path.GetFileName(pathToFile));
    }
}