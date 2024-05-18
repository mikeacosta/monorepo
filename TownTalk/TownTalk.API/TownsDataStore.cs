using TownTalk.API.Models;

namespace TownTalk.API;

public class TownsDataStore
{
    public List<TownDto> Towns { get; set; }

    public static TownsDataStore Current { get; } = new TownsDataStore();

    public TownsDataStore()
    {
        Towns = new List<TownDto>
        {
            new TownDto()
            {
                Id = 1,
                Name = "New York City",
                Description = "The city that never sleeps",
                PointsOfInterest = new List<PointOfInterestDto>
                {
                    new PointOfInterestDto
                    {
                        Id = 1,
                        Name = "Central Park",
                        Description = "The most visited urban park in the United States"
                    },
                    new PointOfInterestDto
                    {
                        Id = 2,
                        Name = "Empire State Building",
                        Description = "102-story skyscraper in Midtown Manhatten"
                    }
                }
            },
            new TownDto()
            {
                Id = 2,
                Name = "London",
                Description = "Mind the gap",
                PointsOfInterest = new List<PointOfInterestDto>
                {
                    new PointOfInterestDto
                    {
                        Id = 3,
                        Name = "Borough Market",
                        Description = "Wholesale and retail food market hall in Southwark"
                    },
                    new PointOfInterestDto
                    {
                        Id = 4,
                        Name = "Camden Town",
                        Description = "Sprawling cluster of markets, shops and an embrace of all things counter culture, offering a concentrated version of London street life"
                    }                    
                }
            },
            new TownDto()
            {
                Id = 3,
                Name = "Oakland",
                Description = "There is no there there",
                PointsOfInterest = new List<PointOfInterestDto>
                {
                    new PointOfInterestDto
                    {
                        Id = 5,
                        Name = "Lake Merritt",
                        Description = "Large tidal lagoon surrounded by parkland and city neighborhoods"
                    },
                    new PointOfInterestDto
                    {
                        Id = 6,
                        Name = "Oakland Zoo",
                        Description = "Long-standing zoo features over 850 native and exotic animals, a wildlife theater andx` educational programs"
                    }                    
                }
            }
        };
    }
}