namespace CodePulse.API.Models;

public class BlogPostDto
{
    public Guid Id { get; set; }
    public String Title { get; set; } = string.Empty;
    public String ShortDescription { get; set; } = string.Empty;
    public String Content { get; set; } = string.Empty;
    public String FeaturedImageUrl { get; set; } = string.Empty;
    public String UrlHandle { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public String Author { get; set; } = string.Empty;
    public bool IsVisible { get; set; }
    public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
}