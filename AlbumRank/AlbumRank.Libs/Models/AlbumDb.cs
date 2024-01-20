using Amazon.DynamoDBv2.DataModel;

namespace AlbumRank.Libs.Models;

[DynamoDBTable("AlbumRank")]
public class AlbumDb
{
    [DynamoDBHashKey]
    public int UserId { get; set; }
    
    [DynamoDBGlobalSecondaryIndexHashKey]
    public string Title { get; set; }
    
    public string Artist { get; set; }

    public int Year { get; set; }
    
    public List<string> Genres { get; set; }

    public int Ranking { get; set; }

    public string DateTimeRanked { get; set; }
}