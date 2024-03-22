using Microsoft.AspNetCore.Mvc;

namespace TownTalk.API.Controllers;

[ApiController]
[Route("api/towns")]
public class TownController : ControllerBase
{
    [HttpGet]
    public JsonResult GetTowns()
    {
        return new JsonResult(
            new List<object>
            {
                new { id = 1, Name = "London"},
                new { id = 2, Name = "Oakland"}
            });
    }
}