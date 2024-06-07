using TownTalk.API.Entities;

namespace TownTalk.API.Services;

public interface ITownTalkRepository
{
    Task<IEnumerable<Town>> GetTownsAsync();

    Task<Town?> GetTownAsync(int townId, bool includePointsOfInterest);
    
    Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForTownAsync(int townId);

    Task<PointOfInterest?> GetPointOfInterestForTownAsync(int townId, int pointOfInterestId);
}