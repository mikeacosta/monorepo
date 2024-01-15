using AlbumRank.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AlbumRank.Controllers;

[Route("albums")]
public class AlbumController : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlbumResponse>>> GetAllItems()
    {
        var results = new List<AlbumResponse>();
        results.Add(new AlbumResponse
        {
            UserId = 1,
            AlbumTitle = "Blue Weekend",
            Artist = "Wolf Alice",
            Year = 2021,
            Generes = new List<string>() { "alternative rock", "indie rock", "dream pop", "shoegaze", "grunge" },
            Ranking = 5,
            DateTimeRanked = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}"
        });
        results.Add(new AlbumResponse
        {
            UserId = 1,
            AlbumTitle = "My Favourite Worst Nightmare",
            Artist = "Artic Monkeys",
            Year = 2007,
            Generes = new List<string>() { "alternative rock", "indie rock", "post-punk revival" },
            Ranking = 4,
            DateTimeRanked = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}"
        });
        
        return Ok(results);
    }
}