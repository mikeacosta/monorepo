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
    private readonly IMapper _mapper;

    public AuthorsController(ICourseStoreRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<AuthorDto>> GetAuthors()
    {
        var list = new List<AuthorDto>();

        var authors = await _repo.GetAuthorsAsync();
        
        foreach (var author in authors)
        {
            var authorDto = _mapper.ToAuthorDto(author);
            
            foreach (var course in author.Courses)
                authorDto.Courses.Add(_mapper.ToCourseDto(course));

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

        var authorDto = _mapper.ToAuthorDto(author);
        
        foreach (var course in author.Courses)
            authorDto.Courses.Add(_mapper.ToCourseDto(course));            
        
        return Ok(authorDto);
    }    
}