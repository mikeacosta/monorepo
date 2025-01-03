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
            list.Add(_mapper.ToAuthorDto(author));
        
        return Ok(list);
    }
    
    [HttpGet("{authorId}", Name = "GetAuthor")]
    public async Task<ActionResult<AuthorDto>> GetAuthor(Guid authorId)
    {
        var author = await _repo.GetAuthorAsync(authorId);
        
        if (author == null)
            return NotFound();

        var authorDto = _mapper.ToAuthorDto(author);
        
        return Ok(authorDto);
    }

    [HttpPost]
    public async Task<ActionResult<AuthorDto>> CreateAuthor(AuthorForCreationDto author)
    {
        var authorEntity = _mapper.ToAuthorEntity(author);
        _repo.AddAuthor(authorEntity);
        await _repo.SaveAsync();
        
        var authorToReturn = _mapper.ToAuthorDto(authorEntity);
        
        return CreatedAtRoute("GetAuthor", 
            new { authorId = authorToReturn.Id }, 
            authorToReturn);
    }
}