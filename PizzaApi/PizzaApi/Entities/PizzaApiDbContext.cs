using Microsoft.EntityFrameworkCore;

namespace PizzaApi.Entities;

public class PizzaApiDbContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; } = null!;
    
    public PizzaApiDbContext(DbContextOptions<PizzaApiDbContext> options)
        : base(options)
    {
    }
}