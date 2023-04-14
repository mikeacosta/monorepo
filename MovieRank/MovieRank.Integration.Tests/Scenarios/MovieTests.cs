using System.Net;
using System.Text;
using MovieRank.Integration.Tests.Setup;
using MovieRank.Libs.Models;
using Newtonsoft.Json;

namespace MovieRank.Integration.Tests.Scenarios;

[Collection("api")]
public class MovieTests : IClassFixture<CustomWebAppFactory>
{
    private readonly HttpClient _client;
    
    public MovieTests(CustomWebAppFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task AddMovieRankDataReturnsOk()
    {
        const int userId = 100;
        
        var data = new MovieDb()
        {
            UserId = userId,
            MovieName = "Test Movie",
            Description = "Test Description",
            Actors = new List<string>()
            {
                "Moe Howard", "Larry Fine", "Curly Howard"
            },
            RankedDateTime = "4/14/2023 10:15:45 AM",
            Ranking = 4
        };

        var json = JsonConvert.SerializeObject(data);
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync($"movies/{userId}", stringContent);
        
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}