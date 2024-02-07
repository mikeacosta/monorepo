using AlbumRank.Contracts;

namespace AlbumRank.Services;

public interface IAlbumRankService
{
    Task<IEnumerable<AlbumResponse>> GetAllItems();
    Task<AlbumResponse> GetAlbum(int userId, string title);
    Task<IEnumerable<AlbumResponse>> GetUserRankedAlbumByTitle(int userId, string title);
    Task AddAlbum(int userId, AlbumRankRequest albumRankRequest);
}