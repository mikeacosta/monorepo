namespace CityInfo.API.Models;

public class CitiesDataStore
{
    public List<CityDto> Cities { get; set; }

    public static CitiesDataStore Current { get; } = new CitiesDataStore();

    public CitiesDataStore()
    {
        Cities = new List<CityDto>()
        {
            new CityDto()
            {
                Id = 1,
                Name = "London",
                Description = "capital of the United Kingdom"
            },
            new CityDto()
            {
                Id = 2,
                Name = "Honolulu",
                Description = "Aloha"
            },
            new CityDto()
            {
                Id = 3,
                Name = "Oakland",
                Description = "There's no there there"
            }
        };
    }
}