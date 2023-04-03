using MovieRank.Contracts;
using MovieRank.Libs.Repositories;

namespace MovieRank.Services;

public class MovieRankService : IMovieRankService
{
    private readonly IMovieRankRepository _movieRankRepository;

    public MovieRankService(IMovieRankRepository movieRankRepository)
    {
        _movieRankRepository = movieRankRepository ?? throw new ArgumentNullException(nameof(movieRankRepository));
    }

    public async Task<IEnumerable<MovieResponse>> GetAllItemsAsync()
    {
        var response = await _movieRankRepository.GetAllItemsAsync();
        var movieContract = response.Select(m => new MovieResponse()
        {
            MovieName = m.MovieName,
            Description = m.Description
        });

        return movieContract;
    }
}