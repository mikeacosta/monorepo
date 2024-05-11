using Microsoft.EntityFrameworkCore;
using TownTalk.API.Entities;

namespace TownTalk.API.DbContexts;

public class TownTalkContext : DbContext
{
    public TownTalkContext(DbContextOptions<TownTalkContext> options) : base(options)
    {
    }    
    
    public DbSet<Town> Towns { get; set; } = null!;
    public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;
}