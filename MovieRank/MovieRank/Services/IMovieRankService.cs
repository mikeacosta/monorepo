using Microsoft.AspNetCore.SignalR;
using MovieRank.Contracts;

namespace MovieRank.Services;

public interface IMovieRankService
{
    Task<IEnumerable<MovieResponse>> GetAllItemsAsync();
    Task<MovieResponse> GetMovieAsync(int userId, string movieName);
    Task<IEnumerable<MovieResponse>> GetUserRankedMoviesByTitleAsync(int userId, string movieName);
    Task AddMovieAsync(int userId, MovieRankRequest movieRankRequest);
}