using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class GimmicksController(AppDbContext context) : BaseApiController
{

    [HttpGet("{id}")]
    public async Task<ActionResult<Gimmick>> GetGimmick(string id)
    {
        var gimmick = await context.Gimmicks.FindAsync(id);
        if (gimmick == null)
            return NotFound();
        
        return gimmick;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Gimmick>>> GetGimmicks()
    {
        return await context.Gimmicks.ToListAsync();
    }
}