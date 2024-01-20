using AlbumRank.Libs.Models;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

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
}