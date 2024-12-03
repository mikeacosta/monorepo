namespace CourseStore.API.Models;

public class AuthorDto
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public ICollection<CourseDto> Courses { get; set; } = new List<CourseDto>();
}