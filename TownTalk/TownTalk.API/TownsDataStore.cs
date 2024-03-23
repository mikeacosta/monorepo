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
                Description = "The city that never sleeps"
            },
            new TownDto()
            {
                Id = 2,
                Name = "London",
                Description = "Mind the gap"
            },
            new TownDto()
            {
                Id = 3,
                Name = "Oakland",
                Description = "There is no there there"
            }
        };
    }
}