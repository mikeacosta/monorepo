namespace CodePulse.API.Models;

public class BlogImageDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = String.Empty;
    public string FileExtension { get; set; } = String.Empty;
    public string Title { get; set; } = String.Empty;
    public string Url { get; set; } = String.Empty;
    public DateTime DateCreated { get; set; }    
}