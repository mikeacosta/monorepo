using Microsoft.AspNetCore.Mvc;
using TownTalk.API.Models;

namespace TownTalk.API.Controllers;

[ApiController]
[Route("api/towns")]
public class TownsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<TownDto>> GetTowns()
    {
        return Ok(TownsDataStore.Current.Towns);
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