namespace AlbumRank.Contracts;

public class AlbumRankRequest
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public int Year { get; set; }
    public List<string> Genres { get; set; }
    public int Ranking { get; set; }
}