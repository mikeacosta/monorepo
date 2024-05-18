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

    public Task<Town?> GetTownAsync(int townId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForTownAsync(int townId)
    {
        throw new NotImplementedException();
    }

    public Task<PointOfInterest?> GetPointOfInterestForTownAsync(int townId, int pointOfInterestId)
    {
        throw new NotImplementedException();
    }
}