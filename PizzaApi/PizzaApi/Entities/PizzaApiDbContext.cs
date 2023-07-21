using Microsoft.EntityFrameworkCore;

namespace PizzaApi.Entities;

public class PizzaApiDbContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; } = null!;
    
    public PizzaApiDbContext(DbContextOptions<PizzaApiDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>().HasData(
            new Pizza("Cheese pizza", "very cheesy") {Id = 1},
            new Pizza("Al Tono pizza", "lots of tuna") {Id = 2}
        );
    }
}