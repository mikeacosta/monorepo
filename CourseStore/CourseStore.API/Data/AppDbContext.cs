using CourseStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.API.Data;

public class AppDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .HasData(
                new Course
                {
                    Id = new Guid("eb57b0d1-7d07-4d1a-81ae-10c2555a78a3"),
                    Title = "Introduction to Psychology",
                    Description = "Comprehensive overview of the scientific study of thought and behavior"
                },
                new Course
                {
                    Id = new Guid("2de47cda-cbd9-4f00-9e5a-6912c37a6c6e"),
                    Title = "Python for Data Science, AI & Development",
                    Description = "Learn Python - the most popular programming language and for Data Science and Software Development"
                }
            ); 
        
        base.OnModelCreating(modelBuilder);
    }
}