using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TownTalk.API.Entities;

public class Town
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    public ICollection<PointOfInterest> PointsOfInterest { get; set; } 
        = new List<PointOfInterest>();

    public Town(string name)
    {
        Name = name;
    }
}