using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkWell.API.Entities;

public class Company
{
    [Key]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [MaxLength(500)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string ContactEmail { get; set; }
    
    public string ContactPhone { get; set; }   
    
    [ForeignKey("JobId")]
    public Job?  Job { get; set; }
    public int JobId { get; set; }
}