using HoopsPlayersAPI.Logic;
using HoopsPlayersAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoopsPlayersAPI.Controllers;

[Route("api/hoopsplayers")]
[ApiController]
public class HoopsPlayersController : ControllerBase
{
    private readonly ILogger<PlayerLogic> _logger;
    private readonly IPlayerLogic _logic;
    
    public HoopsPlayersController(ILogger<PlayerLogic> logger, IPlayerLogic logic)
    {
        _logger = logger;
        _logic = logic;
    }

    [HttpGet]
    public async Task<ActionResult<List<HoopsPlayerDto>>> GetHoopsPlayers()
    {
        var players = await _logic.GetAllPlayers();
        return Ok(players);
    }
    
    [HttpGet("{id}", Name = "HoopsPlayerById")]
    public async Task<ActionResult<HoopsPlayerDto>> GetHoopsPlayerById(int id)
    {
        if (!await _logic.PlayerExists(id))
        {
            _logger.LogInformation($"Player with id {id} not found");
            return NotFound();
        }
        
        var player = await _logic.GetPlayerById(id);
        return Ok(player);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHoopsPlayer([FromBody] CreateHoopsPlayerDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid model object");
        
        var result = await _logic.AddNewPlayer(dto);
        return CreatedAtRoute("HoopsPlayerById", new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHoopsPlayer(int id, [FromBody] UpdateHoopsPlayerDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid model object");
        
        if (!await _logic.PlayerExists(id))
            return NotFound();
        
        await _logic.UpdatePlayer(id, dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHoopsPlayer(int id)
    {
        if (!await _logic.PlayerExists(id))
            return NotFound();

        await _logic.RemovePlayer(id);
        return NoContent();
    }
}