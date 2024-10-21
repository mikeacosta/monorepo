namespace CodePulse.API.Entities;

public class BlogPost
{
    public Guid Id { get; set; }
    public String Title { get; set; } = string.Empty;
    public String ShortDescription { get; set; } = string.Empty;
    public String Content { get; set; } = string.Empty;
    public String FeaturedImageUrl { get; set; } = string.Empty;
    public String UrlHandle { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public String Author { get; set; }
    public bool IsVisible { get; set; }

    public ICollection<Category> Categories { get; set; }
        = new List<Category>();
}