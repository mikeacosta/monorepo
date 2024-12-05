using System.ComponentModel.DataAnnotations;

namespace CourseStore.API.Entities;

public class Author
{
    [Key]
    public Guid Id { get; set; }

    [Required] [MaxLength(50)] public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    
    public ICollection<Course> Courses { get; set; }
        = new List<Course>();
}