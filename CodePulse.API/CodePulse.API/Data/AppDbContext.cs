using CodePulse.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    } 
    
    public DbSet<BlogPost> BlogPosts { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<BlogImage> BlogImages { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasData(
                new Category
                {
                    Id = new Guid("c5eb4603-2e0b-457d-8ed4-da1f29fe4981"),
                    Name = "HTML",
                    UrlHandle = "html-blogs"
                },
                new Category
                {
                    Id = new Guid("8adaae23-11d1-4038-828d-6a4b5a800c52"),
                    Name = "CSS",
                    UrlHandle = "css-blogs"
                },
                new Category
                {
                    Id = new Guid("34540768-eda6-4962-b9e6-ac3976484c4a"),
                    Name = "C#",
                    UrlHandle = "csharp-blogs"
                },
                new Category
                {
                    Id = new Guid("15096235-0b6b-4a6e-9390-2f2a0a6f7b08"),
                    Name = "TypeScript",
                    UrlHandle = "ts-blogs"
                } 
            );
        
        base.OnModelCreating(modelBuilder);
    }
}