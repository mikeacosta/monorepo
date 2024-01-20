using AlbumRank.Libs.Models;

namespace AlbumRank.Libs.Repositories;

public interface IAlbumRankRepository
{
    Task<IEnumerable<AlbumDb>> GetAllItemsFromDb();
}