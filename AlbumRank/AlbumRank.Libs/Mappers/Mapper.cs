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
}