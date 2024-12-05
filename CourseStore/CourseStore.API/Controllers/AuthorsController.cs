using CourseStore.API.Data;
using CourseStore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/authors")]
public class AuthorsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthorsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<AuthorDto>> GetAuthors()
    {
        var list = new List<AuthorDto>();

        var authors = await _context.Authors
            .Include(a => a.Courses).ToListAsync();
        
        foreach (var author in authors)
        {
            var authorDto = new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName
            };
            
            foreach (var course in author.Courses)
            {
                var courseDto = new CourseDto
                {
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description
                };
                authorDto.Courses.Add(courseDto);
            }

            list.Add(authorDto);
        }
        
        return Ok(list);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto>> GetAuthor(Guid id)
    {
        var author = await _context.Authors
            .Include(a => a.Courses)
            .FirstOrDefaultAsync(a => a.Id == id);
        
        if (author == null)
            return NotFound();

        var authorDto = new AuthorDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName
        };
        
        foreach (var course in author.Courses)
        {
            var courseDto = new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description
            };
            authorDto.Courses.Add(courseDto);            
        }
        
        return Ok(authorDto);
    }    
}