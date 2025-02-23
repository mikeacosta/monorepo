namespace CourseStore.API.Models;

public class AuthorForCreationDto
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public ICollection<CourseForCreationDto> Courses { get; set; }
        = new List<CourseForCreationDto>();
}