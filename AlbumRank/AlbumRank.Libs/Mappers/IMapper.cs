using AlbumRank.Contracts;
using AlbumRank.Libs.Models;

namespace AlbumRank.Libs.Mappers;

public interface IMapper
{
    IEnumerable<AlbumResponse> ToAlbumContract(IEnumerable<AlbumDb> items);
    AlbumResponse ToAlbumContract(AlbumDb album);
    AlbumDb ToAlbumDbModel(int userId, AlbumRankRequest albumRankRequest);
    AlbumDb ToAlbumDbModel(int userId, AlbumDb albumDbRequest, AlbumUpdateRequest albumUpdateRequest);
}