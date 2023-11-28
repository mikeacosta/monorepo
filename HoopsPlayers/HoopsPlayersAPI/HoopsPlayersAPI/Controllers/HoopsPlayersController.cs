using HoopsPlayersAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoopsPlayersAPI.Controllers;

[Route("api/hoopsplayers")]
[ApiController]
public class HoopsPlayersController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<HoopsPlayer>>> GetHoopsPlayers()
    {
        return await Task.Run(() => new List<HoopsPlayer>
        {
            new HoopsPlayer
            {
                Id = 1,
                FirstName = "Stephen",
                LastName = "Curry",
                Team = "Warriors",
                Country = "USA"
            }
        });
    }
}