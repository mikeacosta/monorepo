using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseStore.API.Entities;

public class Course
{
    [Key]
    public Guid Id { get; set; }
     
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = String.Empty;

    [MaxLength(1500)]
    public string? Description { get; set; }
    
    [ForeignKey("AuthorId")]
    public Author? Author { get; set; }
    public Guid AuthorId { get; set; }    
}