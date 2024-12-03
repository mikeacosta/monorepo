using System.ComponentModel.DataAnnotations;

namespace CourseStore.API.Entities;

public class Course
{
    [Key]
    public Guid Id { get; set; }
     
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [MaxLength(1500)]
    public string? Description { get; set; }
}