using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using MovieRank.Libs.Models;

namespace MovieRank.Libs.Repositories;

public class MovieRankRepository : IMovieRankRepository
{
    private readonly DynamoDBContext _context;

    public MovieRankRepository(IAmazonDynamoDB client)
    {
        _context = new DynamoDBContext(client);
    }
    
    public async Task<IEnumerable<MovieDb>> GetAllItemsAsync()
    {
        return await _context.ScanAsync<MovieDb>(new List<ScanCondition>()).GetRemainingAsync();
    }

    public async Task<MovieDb> GetMovieAsync(int userId, string movieName)
    {
        return await _context.LoadAsync<MovieDb>(userId, movieName);
    }
}