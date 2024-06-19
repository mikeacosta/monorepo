using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TownTalk.API.Models;
using TownTalk.API.Services;

namespace TownTalk.API.Controllers;

[ApiController]
[Route("api/towns")]
public class TownsController : ControllerBase
{
    private readonly ITownTalkRepository _repository;
    private readonly IMapper _mapper;

    public TownsController(ITownTalkRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TownWithoutPointsOfInterestDto>>> GetTowns()
    {
        var townEntities = await _repository.GetTownsAsync();
        var towns = _mapper.Map<IEnumerable<TownWithoutPointsOfInterestDto>>(townEntities);
        return Ok(towns);
    }

    [HttpGet("{id}")]
    public ActionResult<TownDto> GetTown(int id)
    {
        var town = TownsDataStore.Current.Towns.FirstOrDefault(c => c.Id == id);

        if (town is null)
            return NotFound();
        
        return (Ok(town));
    }
}