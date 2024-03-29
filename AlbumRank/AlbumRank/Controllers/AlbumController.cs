using AlbumRank.Contracts;
using AlbumRank.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlbumRank.Controllers;

[Route("albums")]
public class AlbumController : Controller
{
    private readonly IAlbumRankService _albumRankService;

    public AlbumController(IAlbumRankService albumRankService)
    {
        _albumRankService = albumRankService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlbumResponse>>> GetAllItems()
    {
        var results = await _albumRankService.GetAllItems();
        return Ok(results);
    }

    [HttpGet]
    [Route("{userId}/{title}")]
    public async Task<ActionResult<AlbumResponse>> GetAlbum(int userId, string title)
    {
        var result = await _albumRankService.GetAlbum(userId, title);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("user/{userId}/rankedAlbums/{title}")]
    public async Task<ActionResult<IEnumerable<AlbumResponse>>> GetUserRankedAlbumByTitle(int userId, string title)
    {
        var result = await _albumRankService.GetUserRankedAlbumByTitle(userId, title);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("user/{userId}")]
    public async Task<IActionResult> AddAlbum(int userId, [FromBody] AlbumRankRequest albumRankRequest)
    {
        await _albumRankService.AddAlbum(userId, albumRankRequest);
        return Created($"albums/{userId}/{albumRankRequest.Title}", albumRankRequest);
    }

    [HttpPatch]
    [Route("user/{userId}")]
    public async Task<IActionResult> UpdateAlbum(int userId, [FromBody] AlbumUpdateRequest request)
    {
        await _albumRankService.UpdateAlbum(userId, request);
        return Ok();
    }
    
    [HttpGet]
    [Route("{title}/ranking")]
    public async Task<AlbumRankResponse> GetAlbumRanking(string title)
    {
        var result = await _albumRankService.GetAlbumRank(title);

        return result;
    }    
}