using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.API.Entities;

public class Address
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Address1 { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string? Address2 { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string City { get; set; } = string.Empty;
    
    [MaxLength(2)]
    public string? State { get; set; }
    
    [MaxLength(50)]
    public string? PostalCode { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Country { get; set; } = string.Empty;
    
    [ForeignKey("Company")]
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
}