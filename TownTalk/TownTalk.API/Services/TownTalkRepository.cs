using Microsoft.EntityFrameworkCore;
using TownTalk.API.DbContexts;
using TownTalk.API.Entities;

namespace TownTalk.API.Services;

public class TownTalkRepository : ITownTalkRepository
{
    private readonly TownTalkContext _context;

    public TownTalkRepository(TownTalkContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<Town>> GetTownsAsync()
    {
        return await _context.Towns.OrderBy(t => t.Name).ToListAsync();
    }

    public async Task<Town?> GetTownAsync(int townId, bool includePointsOfInterest)
    {
        if (includePointsOfInterest)
            return await _context.Towns.Include(t => t.PointsOfInterest)
                .Where(t => t.Id == townId).FirstOrDefaultAsync();
        
        return await _context.Towns
            .Where(t => t.Id == townId).FirstOrDefaultAsync();        
    }

    public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForTownAsync(int townId)
    {
        return await _context.PointsOfInterest
            .Where(p => p.TownId == townId)
            .ToListAsync();
    }

    public async Task<PointOfInterest?> GetPointOfInterestForTownAsync(int townId, int pointOfInterestId)
    {
        return await _context.PointsOfInterest
            .Where(p => p.TownId == townId && p.Id == pointOfInterestId)
            .FirstOrDefaultAsync();
    }
}