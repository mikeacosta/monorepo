using MovieRank.Libs.Models;

namespace MovieRank.Libs.Repositories;

public interface IMovieRankRepository
{
    Task<IEnumerable<MovieDb>> GetAllItemsAsync();
    Task<MovieDb> GetMovieAsync(int userId, string movieName);
    Task<IEnumerable<MovieDb>> GetUserRankedMoviesByTitleAsync(int userId, string movieName);
}