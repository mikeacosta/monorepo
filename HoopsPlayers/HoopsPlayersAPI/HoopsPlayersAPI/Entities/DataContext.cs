using HoopsPlayersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HoopsPlayersAPI.Entities;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<HoopsPlayer> HoopsPlayers { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HoopsPlayer>().HasData(
            new HoopsPlayer("Stephen", "Curry", "Warriors", "USA") {Id = 1},
            new HoopsPlayer("Nikola", "Jokic", "Nuggets", "SRB") {Id = 2}
        );
    }
}