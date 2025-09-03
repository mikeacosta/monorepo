using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkWell.API.Entities;

public class Job
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(50)]    
    public string Type { get; set; }
    
    [MaxLength(500)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Location { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Salary { get; set; }
    
    public Company Company { get; set; }
}