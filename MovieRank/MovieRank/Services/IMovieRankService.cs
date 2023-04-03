using MovieRank.Contracts;

namespace MovieRank.Services;

public interface IMovieRankService
{
    public Task<IEnumerable<MovieResponse>> GetAllItemsAsync();
}