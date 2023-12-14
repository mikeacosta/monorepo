using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Admin.Data;

public class ProductDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<Product> Products => Set<Product>();

    public ProductDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            _configuration["ConnectionStrings:DefaultConnectionString"]
        );
    }
    
    public void SeedInitialData()
    {
        if (Products.Any())
        {
            Products.RemoveRange(Products);
            SaveChanges();
        }       

        Products.Add(new Product
        {
            Name = "Trailblazer", Price = 69.99M, IsActive = true,
            Description = "Great support in this high-top to take you to great heights and trails."
        });
        Products.Add(new Product
        {
            Name = "Coastliner", Price = 49.99M, IsActive = true,
            Description =
                "Easy in and out with this lightweight but rugged shoe with great ventilation to get your around shores, beaches, and boats."
        });
        Products.Add(new Product
        {
            Name = "Woodsman", Price = 64.99M, IsActive = true,
            Description =
                "All the insulation and support you need when wandering the rugged trails of the woods and backcountry."
        });
        Products.Add(new Product
        {
            Name = "Basecamp", Price = 249.99M, IsActive = true,
            Description = "Great insulation and plenty of room for 2 in this spacious but highly-portable tent."
        });

        SaveChanges();
    }    
}