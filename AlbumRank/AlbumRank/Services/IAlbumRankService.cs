using AlbumRank.Contracts;

namespace AlbumRank.Services;

public interface IAlbumRankService
{
    Task<IEnumerable<AlbumResponse>> GetAllItems();
}