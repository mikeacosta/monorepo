namespace CodePulse.API.Entities;

public class Category
{
    public Guid Id { get; set; }
    public String Name { get; set; } = string.Empty;
    public String UrlHandle { get; set; } = string.Empty;

    public ICollection<BlogPost> BlogPosts { get; set; }
        = new List<BlogPost>();
}