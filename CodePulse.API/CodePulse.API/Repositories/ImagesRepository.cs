using CodePulse.API.Data;
using CodePulse.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Repositories;

public class ImagesRepository : IImagesRespository
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;
    
    public ImagesRepository(IWebHostEnvironment webHostEnvironment, 
        IHttpContextAccessor httpContextAccessor,
        AppDbContext context)
    {
        _webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
        _context = context;
    }
    
    public async Task<BlogImage> Upload(IFormFile file, BlogImage image)
    {
        var localPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");
        await using var stream = new FileStream(localPath, FileMode.Create);
        await file.CopyToAsync(stream);

        var httpRequest = _httpContextAccessor.HttpContext.Request;
        var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{image.FileName}{image.FileExtension}";

        image.Url = urlPath;
        await _context.BlogImages.AddAsync(image);
        await _context.SaveChangesAsync();
        return image;
    }

    public async Task<IEnumerable<BlogImage>> GetAll()
    {
        return await _context.BlogImages.ToListAsync();
    }
}