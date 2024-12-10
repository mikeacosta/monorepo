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
    private readonly IMapper _mapper;

    public CoursesController(ICourseStoreRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<CourseDto>> GetCoursesForAuthor(Guid authorId)
    {
        var list = new List<CourseDto>();
        
        var courses = await _repo.GetCoursesAsync(authorId);
        foreach (var course in courses)
            list.Add(_mapper.ToCourseDto(course));
        
        return Ok(list);
    }

    [HttpGet("{courseId}", Name = "GetCourse")]
    public async Task<ActionResult<CourseDto>> GetCourse(Guid authorId, Guid courseId)
    {
        if (!await _repo.AuthorExistsAsync(authorId))
            return NotFound();
        
        var course = await _repo.GetCourseAsync(authorId, courseId);
        if (course == null)
            return NotFound();

        var dto = _mapper.ToCourseDto(course);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<CourseDto>> CreateCourse(Guid authorId, CourseForCreationDto course)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if (!await _repo.AuthorExistsAsync(authorId))
            return NotFound();

        var entity = _mapper.ToCourseEntity(course);
        
        _repo.AddCourse(authorId, entity);
        await _repo.SaveAsync();

        var courseToReturn = _mapper.ToCourseDto(entity);
        
        return CreatedAtRoute("GetCourse",
            new
            {
                authorId = authorId,
                courseId = courseToReturn.Id
            },
            courseToReturn);
    }
    
    [HttpPut("{courseId}")]
    public async Task<ActionResult> UpdatePointOfInterest(Guid authorId, Guid courseId,
        CourseForUpdateDto course)
    {
        if (!await _repo.AuthorExistsAsync(authorId))
            return NotFound();

        var courseEntity = await _repo.GetCourseAsync(authorId, courseId);
        if (courseEntity == null)
            return NotFound();

        courseEntity.Title = course.Title;
        courseEntity.Description = course.Description;

        await _repo.SaveAsync();

        return NoContent();
    }    
}