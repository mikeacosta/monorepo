using CourseStore.API.Models;
using CourseStore.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseStore.API.Controllers;

[ApiController]
[Route("api/authorcollections")]
public class AuthorCollectionsController : ControllerBase
{
    private readonly ICourseStoreRepository _repo;
    private readonly IMapper _mapper;

    public AuthorCollectionsController(ICourseStoreRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> CreateAuthorCollection(
        IEnumerable<AuthorForCreationDto> authors)
    {
        var authorEntities = _mapper.ToAuthorEntities(authors);
        foreach (var author in authorEntities)
            _repo.AddAuthor(author);

        await _repo.SaveAsync();

        var result = _mapper.ToAuthorsDtos(authorEntities);
        var authorIds = string.Join(", ", result.Select(a => a.Id));
        return CreatedAtRoute("GetAuthorCollection",
            new { authorIds = authorIds },
            result);
    }

    [HttpGet("({authorIds})", Name = "GetAuthorCollection")]
    public async Task<ActionResult<IEnumerable<AuthorForCreationDto>>> GetAuthorCollection(
            [FromRoute] string authorIds)
    {
        var guids = authorIds.Split(",").Select(id => Guid.Parse(id));
        var entities = await _repo.GetAuthorsAsync(guids);

        if (entities.Count() != guids.Count())
            return NotFound();

        var authorsToReturn = _mapper.ToAuthorsDtos(entities);
        return Ok(authorsToReturn);
    }
}