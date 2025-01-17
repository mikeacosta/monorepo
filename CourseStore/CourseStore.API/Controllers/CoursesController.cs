using CourseStore.API.Entities;
using CourseStore.API.Models;
using CourseStore.API.Services;
using Microsoft.AspNetCore.JsonPatch;
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
    public async Task<IActionResult> UpdateCourse(Guid authorId, Guid courseId,
        CourseForUpdateDto course)
    {
        if (!await _repo.AuthorExistsAsync(authorId))
            return NotFound();

        var courseEntity = await _repo.GetCourseAsync(authorId, courseId);
        if (courseEntity == null)
        {
            var courseToAdd = _mapper.ToCourseEntity(course);
            courseToAdd.Id = courseId;
;           _repo.AddCourse(authorId, courseToAdd);
            await _repo.SaveAsync();

            var courseToReturn = _mapper.ToCourseDto(courseToAdd);
            return CreatedAtRoute("GetCourse",
                new
                {
                    authorId = authorId,
                    courseId = courseToReturn.Id
                },
                courseToReturn);            
        }

        courseEntity.Title = course.Title;
        courseEntity.Description = course.Description;

        await _repo.SaveAsync();

        return NoContent();
    }

    [HttpPatch("{courseId}")]
    public async Task<IActionResult> PartiallyUpdateCourse(Guid authorId, Guid courseId,
        JsonPatchDocument<CourseForUpdateDto> patchDocument)
    {
        if (!await _repo.AuthorExistsAsync(authorId))
            return NotFound();

        var courseEntity = await _repo.GetCourseAsync(authorId, courseId);
        if (courseEntity == null)
            return NotFound();    
        
        var courseToPatch = new CourseForUpdateDto()
        {
            Title = courseEntity.Title,
            Description = courseEntity.Description
        };    
        patchDocument.ApplyTo(courseToPatch);
        
        courseEntity.Title = courseToPatch.Title;
        courseEntity.Description = courseToPatch.Description;

        await _repo.SaveAsync();

        return NoContent();
    }
}