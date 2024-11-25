namespace Company.API.Models;

public class ContactDto
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public string? Email { get; set; }
}