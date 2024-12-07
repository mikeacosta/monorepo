using CourseStore.API.Entities;
using CourseStore.API.Models;
using CourseStore.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseStore.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/authors/{authorId}/courses")]
public class CoursesController : ControllerBase
{
    private readonly ICourseStoreRepository _repo;

    public CoursesController(ICourseStoreRepository repo)
    {
        _repo = repo;
    }
    
    [HttpGet]
    public async Task<ActionResult<CourseDto>> GetCoursesForAuthor(Guid authorId)
    {
        var list = new List<CourseDto>();
        
        var courses = await _repo.GetCoursesAsync(authorId);
        foreach (var course in courses)
        {
            var dto = new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description
            };
            list.Add(dto);
        }
        
        return Ok(list);
    }

    [HttpGet("{courseId}")]
    public async Task<ActionResult<CourseDto>> GetCourse(Guid authorId, Guid courseId)
    {
        if (!await _repo.AuthorExistsAsync(authorId))
            return NotFound();
        
        var course = await _repo.GetCourseAsync(authorId, courseId);
        if (course == null)
            return NotFound();

        var dto = new CourseDto
        {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description
        };
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<CourseDto>> CreateCourse(Guid authorId, CourseForCreationDto course)
    {
        if (!await _repo.AuthorExistsAsync(authorId))
            return NotFound();

        var entity = new Course
        {
            Title = course.Title,
            Description = course.Description
        };
        
        _repo.AddCourse(authorId, entity);
        await _repo.SaveAsync();

        return new CourseDto
        {
            Id = entity.Id,
            Title = course.Title,
            Description = course.Description
        };
    }
}