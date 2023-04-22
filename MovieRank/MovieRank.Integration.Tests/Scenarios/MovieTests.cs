using System.Net;
using System.Text;
using MovieRank.Contracts;
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
        var response = await AddMovieRankData(userId);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
    
    [Fact]
    public async Task GetAllItemsFromDatabaseReturnsNotNullMovieResponse()
    {
        const int userId = 200;
        await AddMovieRankData(userId);
        var response = await _client.GetAsync("movies");

        MovieResponse[] result;
        using (var content = response.Content.ReadAsStringAsync())
        {
            result = JsonConvert.DeserializeObject<MovieResponse[]>(await content);
        }
        
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetMovieReturnsExpectedName()
    {
        const int userId = 300;
        const string movieName = "Test Movie";
        
        await AddMovieRankData(userId);
        var response = await _client.GetAsync($"movies/{userId}/{movieName}");
        
        MovieResponse result;
        using (var content = response.Content.ReadAsStringAsync())
        {
            result = JsonConvert.DeserializeObject<MovieResponse>(await content);
        }

        Assert.Equal(movieName, result.MovieName);
    }

    [Fact]
    public async Task UpdateMovieReturnMovieRankValue()
    {
        const int userId = 400;
        const string movieName = "Updated Movie";
        const int ranking = 10;
        
        await AddMovieRankData(userId, movieName);

        var updateMovie = new MovieUpdateRequest()
        {
            MovieName = movieName,
            Ranking = ranking
        };

        var json = JsonConvert.SerializeObject(updateMovie);
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        await _client.PatchAsync($"movies/{userId}", stringContent);

        var response = await _client.GetAsync($"movies/{userId}/{movieName}");

        MovieResponse result;
        using (var content = response.Content.ReadAsStringAsync())
        {
            result = JsonConvert.DeserializeObject<MovieResponse>(await content);
        }

        Assert.Equal(ranking, result.Ranking);     
    }

    private async Task<HttpResponseMessage> AddMovieRankData(int testUserId, string movieName = "Test Movie")
    {
        var data = new MovieDb()
        {
            UserId = testUserId,
            MovieName = movieName,
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
        return await _client.PostAsync($"movies/{testUserId}", stringContent);
    }
}