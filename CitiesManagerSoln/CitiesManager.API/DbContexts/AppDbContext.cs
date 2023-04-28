using CitiesManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CitiesManager.API.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public AppDbContext()
    {
    }
    
    public virtual DbSet<City> Cities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<City>().HasData(new City()
        {
            ID = new Guid("7EE39980-2D05-4A16-9108-371B32C48D61"),
            Name = "London"
        });
        modelBuilder.Entity<City>().HasData(new City()
        {
            ID = new Guid("2A5DEA96-33E1-4EF7-BBAB-58562CD2B82B"),
            Name = "Honolulu"
        });
    }
}