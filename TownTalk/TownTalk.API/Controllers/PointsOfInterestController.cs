using Microsoft.AspNetCore.Mvc;
using TownTalk.API.Models;

namespace TownTalk.API.Controllers;

[ApiController]
[Route("api/towns/{townId}/pointsofinterest")]
public class PointsOfInterestController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int townId)
    {
        var town = TownsDataStore.Current.Towns.FirstOrDefault(t => t.Id == townId);

        if (town is null)
            return NotFound();

        return Ok(town.PointsOfInterest);
    }

    [HttpGet("{pointOfInterestId}")]
    public ActionResult<PointOfInterestDto> GetPointOfInterest(int townId, int pointOfInterestId)
    {
        var town = TownsDataStore.Current.Towns.FirstOrDefault(t => t.Id == townId);
    
        if (town is null)
            return NotFound();

        var pointOfInterest = town.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);

        if (pointOfInterest is null)
            return NotFound();

        return Ok(pointOfInterest);
    }
}