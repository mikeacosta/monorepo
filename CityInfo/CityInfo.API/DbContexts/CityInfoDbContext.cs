using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts;

public class CityInfoDbContext : DbContext
{
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;

    public CityInfoDbContext(DbContextOptions<CityInfoDbContext> options) 
        : base(options) 
    {

    }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(
               new City("London")
               {
                   Id = 1,
                   Description = "Capital of the United Kingdom"
               },
               new City("Honolulu")
               {
                   Id = 2,
                   Description = "Aloha"
               },
               new City("Oakland")
               {
                   Id = 3,
                   Description = "There's no there there"
               });

            modelBuilder.Entity<PointOfInterest>()
             .HasData(
               new PointOfInterest("Borough Market")
               {
                   Id = 1,
                   CityId = 1,
                   Description = "One of London's oldest food markets"
               },
               new PointOfInterest("Tower of London")
               {
                   Id = 2,
                   CityId = 1,
                   Description = "Historic castle with over 1,000 years of history"
               },
                 new PointOfInterest("Waikiki Beach")
                 {
                     Id = 3,
                     CityId = 2,
                     Description = "This iconic landmark in Waikiki is one of Hawaii's most famous beaches"
                 },
               new PointOfInterest("Diamond Head")
               {
                   Id = 4,
                   CityId = 2,
                   Description = "Popular volcanic tuff cone on Oahu"
               },
               new PointOfInterest("Jack London Square")
               {
                   Id = 5,
                   CityId = 3,
                   Description = "Entertainment and business destination on the waterfront"
               },
               new PointOfInterest("Lake Merritt")
               {
                   Id = 6,
                   CityId = 3,
                   Description = "Large tidal lagoon in the center of Oakland"
               }
               );
            base.OnModelCreating(modelBuilder);
        }
}