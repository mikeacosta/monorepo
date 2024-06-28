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
}