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
        return Ok();    // TODO: change to CreatedAtRoute()
    }
}