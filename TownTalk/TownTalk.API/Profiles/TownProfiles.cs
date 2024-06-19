using AutoMapper;

namespace TownTalk.API.Profiles;

public class TownProfiles : Profile
{
    public TownProfiles()
    {
        CreateMap<Entities.Town, Models.TownWithoutPointsOfInterestDto>();
    }
}