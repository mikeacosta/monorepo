using Microsoft.AspNetCore.Mvc;
using TownTalk.API.Models;
using TownTalk.API.Services;

namespace TownTalk.API.Controllers;

[ApiController]
[Route("api/towns")]
public class TownsController : ControllerBase
{
    private readonly ITownTalkRepository _repository;

    public TownsController(ITownTalkRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TownWithoutPointsOfInterestDto>>> GetTowns()
    {
        var townEntities = await _repository.GetTownsAsync();
        var towns = townEntities.Select(t => new TownWithoutPointsOfInterestDto
        {
            Id = t.Id,
            Name = t.Name,
            Description = t.Description
        });
        return Ok(towns);
    }

    [HttpGet("{id}")]
    public ActionResult<TownDto> GetCity(int id)
    {
        var town = TownsDataStore.Current.Towns.FirstOrDefault(c => c.Id == id);

        if (town is null)
            return NotFound();
        
        return (Ok(town));
    }
}