using AutoMapper;
using HoopsPlayersAPI.Entities;
using HoopsPlayersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoopsPlayersAPI.Controllers;

[Route("api/hoopsplayers")]
[ApiController]
public class HoopsPlayersController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    
    public HoopsPlayersController(DataContext dataContext,
        IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<HoopsPlayerDto>>> GetHoopsPlayers()
    {
        var players = await _dataContext.HoopsPlayers.OrderBy(p => p.Id).ToListAsync();
        var dtos = _mapper.Map<IEnumerable<HoopsPlayerDto>>(players);
        return Ok(dtos);
    }
    
    [HttpGet("{id}", Name = "HoopsPlayerById")]
    public async Task<ActionResult<HoopsPlayerDto>> GetHoopsPlayerById(int id)
    {
        var player = await _dataContext.HoopsPlayers.FindAsync(id);
        if (player == null)
            return NotFound();
        
        var dto = _mapper.Map<HoopsPlayerDto>(player);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHoopsPlayer([FromBody] CreateHoopsPlayerDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid model object");

        var player = _mapper.Map<HoopsPlayer>(dto);

        await _dataContext.AddAsync(player);
        await _dataContext.SaveChangesAsync();
        
        var result = _mapper.Map<HoopsPlayerDto>(player);
        return CreatedAtRoute("HoopsPlayerById", new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHoopsPlayer(int id, [FromBody] UpdateHoopsPlayerDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid model object");

        var playerEntity = await _dataContext.HoopsPlayers.FindAsync(id);
        if (playerEntity is null)
            return NotFound();

        _mapper.Map(dto, playerEntity);
        await _dataContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHoopsPlayer(int id)
    {
        var playerEntity = await _dataContext.HoopsPlayers.FindAsync(id);
        if (playerEntity is null)
            return NotFound();

        _dataContext.HoopsPlayers.Remove(playerEntity);
        await _dataContext.SaveChangesAsync();
        return NoContent();
    }
}