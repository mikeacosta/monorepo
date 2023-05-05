using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Data;

public class BethanysPieShopDbContext : DbContext
{
    public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext> options) 
        : base(options)
    {
    }

    private DbSet<Category> Categories { get; set; }
    private DbSet<Pie> Pies { get; set; }
}