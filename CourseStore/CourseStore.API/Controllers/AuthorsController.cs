using CourseStore.API.Models;
using CourseStore.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseStore.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/authors")]
public class AuthorsController : ControllerBase
{
    private readonly ICourseStoreRepository _repo;

    public AuthorsController(ICourseStoreRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<AuthorDto>> GetAuthors()
    {
        var list = new List<AuthorDto>();

        var authors = await _repo.GetAuthorsAsync();
        
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
    
    [HttpGet("{authorId}")]
    public async Task<ActionResult<AuthorDto>> GetAuthor(Guid authorId)
    {
        var author = await _repo.GetAuthorAsync(authorId);
        
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