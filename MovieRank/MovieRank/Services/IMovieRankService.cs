using MovieRank.Contracts;

namespace MovieRank.Services;

public interface IMovieRankService
{
    Task<IEnumerable<MovieResponse>> GetAllItemsAsync();
    Task<MovieResponse> GetMovieAsync(int userId, string movieName);
}