using Microsoft.AspNetCore.Mvc;
using MovieRank.Contracts;
using MovieRank.Services;

namespace MovieRank.Controllers;

[Route("movies")]
public class MovieController : ControllerBase
{
    private readonly IMovieRankService _movieRankService;

    public MovieController(IMovieRankService movieRankService)
    {
        _movieRankService = movieRankService ?? throw new ArgumentNullException(nameof(movieRankService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieResponse>>> GetAllItems()
    {
        var results = await _movieRankService.GetAllItemsAsync();
        return Ok(results);
    }
    
    [HttpGet]
    [Route("{userId}/{movieName}")]
    public async Task<ActionResult<MovieResponse>> GetMovie(int userId, string movieName)
    {
        var result = await _movieRankService.GetMovieAsync(userId, movieName);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("user/{userId}/rankedMovies/{movieName}")]
    public async Task<ActionResult<IEnumerable<MovieResponse>>> GetUserRankedMoviesByTitle(int userId, string movieName)
    {
        var result = await _movieRankService.GetUserRankedMoviesByTitleAsync(userId, movieName);
        return Ok(result);
    }

    [HttpPost]
    [Route("{userId}")]
    public async Task<IActionResult> AddMovie(int userId, [FromBody] MovieRankRequest movieRankRequest)
    {
        await _movieRankService.AddMovieAsync(userId, movieRankRequest);
        return Created($"movies/{userId}/{movieRankRequest.MovieName}", movieRankRequest);
    }

    [HttpPatch]
    [Route("{userId}")]
    public async Task<IActionResult> UpdateMovie(int userId, [FromBody] MovieUpdateRequest movieUpdateRequest)
    {
        await _movieRankService.UpdateMovieAsync(userId, movieUpdateRequest);
        return Ok();
    }

    [HttpGet]
    [Route("{movieName}/ranking")]
    public async Task<ActionResult<MovieRankResponse>> GetMoviesRanking(string movieName)
    {
        var result = await _movieRankService.GetMovieRankAsync(movieName);
        return Ok(result);
    }
}