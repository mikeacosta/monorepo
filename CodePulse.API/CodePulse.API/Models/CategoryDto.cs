namespace CodePulse.API.Models;

public class CategoryDto
{
    public Guid Id { get; set; }
    public String Name { get; set; } = string.Empty;
    public String UrlHandle { get; set; } = string.Empty;
}