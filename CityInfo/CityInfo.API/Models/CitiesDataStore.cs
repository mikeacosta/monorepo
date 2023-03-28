namespace CityInfo.API.Models;

public class CitiesDataStore
{
    public List<CityDto> Cities { get; set; }

    // public static CitiesDataStore Current { get; } = new CitiesDataStore();

    public CitiesDataStore()
    {
        Cities = new List<CityDto>()
        {
            new CityDto()
            {
                Id = 1,
                Name = "London",
                Description = "capital of the United Kingdom",
                PointsOfInterest = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        Id = 1, 
                        Name = "Borough Market", 
                        Description = "One of London's oldest food markets"
                    },
                    new PointOfInterestDto()
                    {
                        Id = 2, 
                        Name = "Tower of London", 
                        Description = "Historic castle with over 1,000 years of history"
                    }
                }
            },
            new CityDto()
            {
                Id = 2,
                Name = "Honolulu",
                Description = "Aloha",
                PointsOfInterest = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        Id = 3, 
                        Name = "Waikiki Beach", 
                        Description = "This iconic landmark in Waikiki is one of Hawaii's most famous beaches"
                    },
                    new PointOfInterestDto()
                    {
                        Id = 4, 
                        Name = "Diamond Head", 
                        Description = "Popular volcanic tuff cone on Oahu"
                    }
                }
            },
            new CityDto()
            {
                Id = 3,
                Name = "Oakland",
                Description = "There's no there there",
                PointsOfInterest = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        Id = 5, 
                        Name = "Jack London Square", 
                        Description = "Entertainment and business destination on the waterfront"
                    },
                    new PointOfInterestDto()
                    {
                        Id = 6, 
                        Name = "Lake Merritt", 
                        Description = "Large tidal lagoon in the center of Oakland"
                    }
                }
            }
        };
    }
}