using Microsoft.AspNetCore.Mvc;

namespace TownTalk.API.Controllers;

[ApiController]
[Route("api/towns")]
public class TownController : ControllerBase
{
    [HttpGet]
    public JsonResult GetTowns()
    {
        return new JsonResult(TownsDataStore.Current.Towns);
    }

    [HttpGet("{id}")]
    public JsonResult GetCity(int id)
    {
        var town = TownsDataStore.Current.Towns.FirstOrDefault(c => c.Id == id);
        return new JsonResult(town);
    }
}