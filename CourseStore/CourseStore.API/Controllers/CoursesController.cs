using CourseStore.API.Data;
using CourseStore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CoursesController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<CourseDto>> GetCourses()
    {
        var list = new List<CourseDto>();
        
        var courses = await _context.Courses.ToListAsync();
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

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseDto>> GetCourse(Guid id)
    {
        var course = await _context.Courses.FindAsync(id);
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
}