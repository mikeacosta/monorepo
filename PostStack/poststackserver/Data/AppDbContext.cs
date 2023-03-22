using Microsoft.EntityFrameworkCore;

namespace poststackserver.Data;


internal sealed class AppDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) =>
        dbContextOptionsBuilder.UseSqlite("DataSource=./Data/AppDB.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Post[] initialPosts = new Post[6];

        for (int i = 1; i <= initialPosts.Length; i++)
        {
            initialPosts[i - 1] = new Post()
            {
                PostId = i + 1,
                Title = $"Post {i}",
                Content = $"This is content for post {i}."
            };
        }

        modelBuilder.Entity<Post>().HasData(initialPosts);
    }
}