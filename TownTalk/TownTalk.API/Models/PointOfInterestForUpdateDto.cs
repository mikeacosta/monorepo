using System.ComponentModel.DataAnnotations;

namespace TownTalk.API.Models;

public class PointOfInterestForUpdateDto
{
    [Required (ErrorMessage = "Name required for Point of Interest.")]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}