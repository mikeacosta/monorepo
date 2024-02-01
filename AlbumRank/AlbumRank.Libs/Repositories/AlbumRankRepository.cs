using AlbumRank.Libs.Models;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace AlbumRank.Libs.Repositories;

public class AlbumRankRepository : IAlbumRankRepository
{
    private readonly DynamoDBContext _context;

    public AlbumRankRepository(IAmazonDynamoDB client)
    {
        _context = new DynamoDBContext(client);
    }
    
    public async Task<IEnumerable<AlbumDb>> GetAllItemsFromDb()
    {
        return await _context.ScanAsync<AlbumDb>(new List<ScanCondition>()).GetRemainingAsync();
    }

    public async Task<AlbumDb> GetAlbum(int userId, string title)
    {
        return await _context.LoadAsync<AlbumDb>(userId, title);
    }

    public async Task<IEnumerable<AlbumDb>> GetUsersRankedAlbumsByTitle(int userId, string title)
    {
        var config = new DynamoDBOperationConfig()
        {
            QueryFilter = new List<ScanCondition>()
            {
                new ScanCondition("Title", ScanOperator.BeginsWith, title)
            }
        };

        return await _context.QueryAsync<AlbumDb>(userId, config).GetRemainingAsync();
    }
}