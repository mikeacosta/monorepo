using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoopsPlayersAPI.Entities;

[Table("HoopsPlayers")]
public class HoopsPlayer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Team { get; set; }
    
    [MaxLength(3)]
    public string Country { get; set; }

    public HoopsPlayer(string firstName, string lastName, string team, string country = "")
    {
        FirstName = firstName;
        LastName = lastName;
        Team = team;
        Country = country;
    }
}