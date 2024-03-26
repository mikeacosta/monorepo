using System.Drawing;

namespace TownTalk.API.Models;

public class TownDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public int NumberOfPointsOfInterest
    {
        get
        {
            return PointsOfInterest.Count;
        }
    }
    
    public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } 
        = new List<PointOfInterestDto>();
}