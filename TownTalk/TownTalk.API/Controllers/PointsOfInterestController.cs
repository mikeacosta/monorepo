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

    [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
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

    [HttpPost]
    public ActionResult<PointOfInterestDto> CreatePointOfInterest(int townId, 
        PointOfInterestForCreationDto pointOfInterest)
    {
        var town = TownsDataStore.Current.Towns.FirstOrDefault(t => t.Id == townId);
        if (town is null)
            return NotFound();

        // refactor this
        var maxPointOfInterestId = TownsDataStore.Current.Towns
            .SelectMany(t => t.PointsOfInterest)
            .Max(p => p.Id);

        var finalPointOfInterest = new PointOfInterestDto
        {
            Id = ++maxPointOfInterestId,
            Name = pointOfInterest.Name,
            Description = pointOfInterest.Description
        };
        
        town.PointsOfInterest.Add(finalPointOfInterest);

        return CreatedAtRoute("GetPointOfInterest", new
        {
            townId = townId,
            pointOfInterestId = finalPointOfInterest.Id
        }, finalPointOfInterest);
    }

    [HttpPut("{pointofinterestid}")]
    public ActionResult UpdatePointOfInterest(int townId, int pointOfInterestId,
        PointOfInterestForUpdateDto pointOfInterest)
    {
        var town = TownsDataStore.Current.Towns.FirstOrDefault(t => t.Id == townId);
        if (town is null)
            return NotFound();

        var pointOfInterestFromStore = town.PointsOfInterest
            .FirstOrDefault(p => p.Id == pointOfInterestId);
        if (pointOfInterestFromStore is null)
            return NotFound();

        pointOfInterestFromStore.Name = pointOfInterest.Name;
        pointOfInterestFromStore.Description = pointOfInterest.Description;

        return NoContent();
    }
}