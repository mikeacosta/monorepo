using AutoMapper;
using HoopsPlayersAPI.Entities;
using HoopsPlayersAPI.Models;

namespace HoopsPlayersAPI.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<HoopsPlayer, HoopsPlayerDto>();
        CreateMap<CreateHoopsPlayerDto, HoopsPlayer>();
    }
}