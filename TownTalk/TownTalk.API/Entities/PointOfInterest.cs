using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TownTalk.API.Entities;

public class PointOfInterest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    [ForeignKey("TownId")]
    public Town? Town { get; set; }
    public int TownId { get; set; }

    public PointOfInterest(string name)
    {
        Name = name;
    }
}