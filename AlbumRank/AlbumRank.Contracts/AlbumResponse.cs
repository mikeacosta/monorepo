namespace AlbumRank.Contracts;

public class AlbumResponse
{
    public int UserId { get; set; }

    public string AlbumTitle { get; set; }

    public string Artist { get; set; }
    
    public int Year { get; set; }

    public List<string> Generes { get; set; }

    public int Ranking { get; set; }

    public string DateTimeRanked { get; set; }
}