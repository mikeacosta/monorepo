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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<Town>()
                .HasData(
               new Town("London")
               {
                   Id = 1,
                   Description = "Capital of the United Kingdom"
               },
               new Town("Honolulu")
               {
                   Id = 2,
                   Description = "Aloha"
               },
               new Town("Oakland")
               {
                   Id = 3,
                   Description = "There's no there there"
               });

            modelBuilder.Entity<PointOfInterest>()
             .HasData(
               new PointOfInterest("Borough Market")
               {
                   Id = 1,
                   TownId = 1,
                   Description = "One of London's oldest food markets"
               },
               new PointOfInterest("Tower of London")
               {
                   Id = 2,
                   TownId = 1,
                   Description = "Historic castle with over 1,000 years of history"
               },
                 new PointOfInterest("Waikiki Beach")
                 {
                     Id = 3,
                     TownId = 2,
                     Description = "This iconic landmark in Waikiki is one of Hawaii's most famous beaches"
                 },
               new PointOfInterest("Diamond Head")
               {
                   Id = 4,
                   TownId = 2,
                   Description = "Popular volcanic tuff cone on Oahu"
               },
               new PointOfInterest("Jack London Square")
               {
                   Id = 5,
                   TownId = 3,
                   Description = "Entertainment and business destination on the waterfront"
               },
               new PointOfInterest("Lake Merritt")
               {
                   Id = 6,
                   TownId = 3,
                   Description = "Large tidal lagoon in the center of Oakland"
               }
               );
            base.OnModelCreating(modelBuilder);        
    }
}