using MovieRank.Libs.Models;

namespace MovieRank.Libs.Repositories;

public interface IMovieRankRepository
{
    public Task<IEnumerable<MovieDb>> GetAllItemsAsync();
}