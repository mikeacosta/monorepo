using System.Globalization;
using MovieRank.Contracts;
using MovieRank.Libs.Models;

namespace MovieRank.Libs.Mappers;

public class Mapper : IMapper
{
    public IEnumerable<MovieResponse> ToMovieContract(IEnumerable<MovieDb> items)
    {
        return items.Select(ToMovieContract);
    }

    public MovieResponse ToMovieContract(MovieDb movie)
    {
        return new MovieResponse()
        {
            UserId = movie.UserId,
            MovieName = movie.MovieName,
            Description = movie.Description,
            Actors = movie.Actors,
            Ranking = movie.Ranking,
            TimeRanked = movie.RankedDateTime
        };
    }

    public MovieDb ToMovieDbModel(int userId, MovieRankRequest movieRankRequest)
    {
        return new MovieDb()
        {
            UserId = userId,
            MovieName = movieRankRequest.MovieName,
            Description = movieRankRequest.Description,
            Actors = movieRankRequest.Actors,
            Ranking = movieRankRequest.Ranking,
            RankedDateTime = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)
        };
    }

    public MovieDb ToMovieDbModel(int userId, MovieDb movieDbRequest, MovieUpdateRequest movieUpdateRequest)
    {
        return new MovieDb()
        {
            UserId = movieDbRequest.UserId,
            MovieName = movieDbRequest.MovieName,
            Description = movieDbRequest.Description,
            Actors = movieDbRequest.Actors,
            Ranking = movieUpdateRequest.Ranking,
            RankedDateTime = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)
        };
    }
}