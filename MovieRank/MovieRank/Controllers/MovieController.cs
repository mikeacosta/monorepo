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
    
    [HttpGet]
    [Route("user/{userId}/rankedMovies/{movieName}")]
    public async Task<IEnumerable<MovieResponse>> GetUserRankedMoviesByTitle(int userId, string movieName)
    {
        var result = await _movieRankService.GetUserRankedMoviesByTitleAsync(userId, movieName);
        return result;
    }

    [HttpPost]
    [Route("{userId}")]
    public async Task<IActionResult> AddMovie(int userId, [FromBody] MovieRankRequest movieRankRequest)
    {
        await _movieRankService.AddMovieAsync(userId, movieRankRequest);
        return Created($"movies/{userId}/{movieRankRequest.MovieName}", movieRankRequest);
    }
}