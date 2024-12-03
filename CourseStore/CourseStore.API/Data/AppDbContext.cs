using CourseStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.API.Data;

public class AppDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Course> Courses { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasData(
                new Author
                {
                    Id = new Guid("7b863cb7-d866-4322-8e2c-136518f08855"),
                    FirstName = "Daniel",
                    LastName = "Kowalski"
                },
                new Author
                {
                    Id = new Guid("5070b038-5bd7-45b6-94ec-ad1483384997"),
                    FirstName = "Fred",
                    LastName = "Jones"
                }
            );
        
        modelBuilder.Entity<Course>()
            .HasData(
                new Course
                {
                    Id = new Guid("eb57b0d1-7d07-4d1a-81ae-10c2555a78a3"),
                    Title = "Introduction to Psychology",
                    Description = "Comprehensive overview of the scientific study of thought and behavior",
                    AuthorId = new Guid("7b863cb7-d866-4322-8e2c-136518f08855")
                },
                new Course
                {
                    Id = new Guid("2de47cda-cbd9-4f00-9e5a-6912c37a6c6e"),
                    Title = "Python for Data Science, AI & Development",
                    Description = "Learn Python - the most popular programming language and for Data Science and Software Development",
                    AuthorId = new Guid("7b863cb7-d866-4322-8e2c-136518f08855")
                }
            ); 
        
        base.OnModelCreating(modelBuilder);
    }
}