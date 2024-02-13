using System.Globalization;
using AlbumRank.Contracts;
using AlbumRank.Libs.Models;

namespace AlbumRank.Libs.Mappers;

public class Mapper : IMapper
{
    public IEnumerable<AlbumResponse> ToAlbumContract(IEnumerable<AlbumDb> items)
    {
        return items.Select(ToAlbumContract);
    }
    
    public AlbumResponse ToAlbumContract(AlbumDb album)
    {
        return new AlbumResponse
        {
            UserId = album.UserId,
            Title = album.Title,
            Artist = album.Artist,
            Year = album.Year,
            Generes = album.Genres,
            Ranking = album.Ranking,
            DateTimeRanked = album.DateTimeRanked
        };
    }

    public AlbumDb ToAlbumDbModel(int userId, AlbumRankRequest albumRankRequest)
    {
        return new AlbumDb()
        {
            UserId = userId,
            Title = albumRankRequest.Title,
            Artist = albumRankRequest.Artist,
            Year = albumRankRequest.Year,
            Genres = albumRankRequest.Genres,
            Ranking = albumRankRequest.Ranking,
            DateTimeRanked = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)
        };
    }

    public AlbumDb ToAlbumDbModel(int userId, AlbumDb albumDbRequest, AlbumUpdateRequest albumUpdateRequest)
    {
        return new AlbumDb()
        {
            UserId = userId,
            Title = albumDbRequest.Title,
            Artist = albumDbRequest.Artist,
            Year = albumDbRequest.Year,
            Genres = albumDbRequest.Genres,
            Ranking = albumUpdateRequest.Ranking,
            DateTimeRanked = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)
        };
    }
}