using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class HouseDbContext : DbContext
{
    public DbSet<HouseEntity> Houses => Set<HouseEntity>();
    
    public HouseDbContext(DbContextOptions<HouseDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<HouseEntity>().HasData(
            new HouseEntity
            {
                Id = 1,
                Address = "6630 Heartwood Drive, Oakland, CA  94611",
                Country = "United States",
                Description = "Iconic home in the Oakland Hills",
                Price = 3000000
            },
            new HouseEntity
            {
                Id = 2,
                Address = "12 Valley of Kings, Geneva",
                Country = "Switzerland",
                Description = "A superb, detached Victorian property",
                Price = 900000              
            }
        );
    }
}