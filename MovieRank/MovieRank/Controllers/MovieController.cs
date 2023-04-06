using Microsoft.AspNetCore.Mvc;
using MovieRank.Contracts;
using MovieRank.Services;

namespace MovieRank.Controllers;

[Route("movies")]
public class MovieController : Controller
{
    private readonly IMovieRankService _movieRankService;

    public MovieController(IMovieRankService movieRankService)
    {
        _movieRankService = movieRankService ?? throw new ArgumentNullException(nameof(movieRankService));
    }

    [HttpGet]
    public async Task<IEnumerable<MovieResponse>> GetAllItems()
    {
        var results = await _movieRankService.GetAllItemsAsync();
        return results;
    }
    
    [HttpGet]
    [Route("{userId}/{movieName}")]
    public async Task<MovieResponse> GetMovie(int userId, string movieName)
    {
        var result = await _movieRankService.GetMovieAsync(userId, movieName);
        return result;
    }
}