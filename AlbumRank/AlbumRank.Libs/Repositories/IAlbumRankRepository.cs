using AlbumRank.Libs.Models;

namespace AlbumRank.Libs.Repositories;

public interface IAlbumRankRepository
{
    Task<IEnumerable<AlbumDb>> GetAllItemsFromDb();
    Task<AlbumDb> GetAlbum(int userId, string title);
    Task<IEnumerable<AlbumDb>> GetUsersRankedAlbumsByTitle(int userId, string title);
}