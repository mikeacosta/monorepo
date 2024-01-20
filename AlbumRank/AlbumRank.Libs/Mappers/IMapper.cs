using AlbumRank.Contracts;
using AlbumRank.Libs.Models;

namespace AlbumRank.Libs.Mappers;

public interface IMapper
{
    IEnumerable<AlbumResponse> ToAlbumContract(IEnumerable<AlbumDb> items);
    AlbumResponse ToAlbumContract(AlbumDb album);
}