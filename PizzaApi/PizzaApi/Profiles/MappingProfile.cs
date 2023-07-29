using AutoMapper;
using PizzaApi.Entities;
using PizzaApi.Models;

namespace PizzaApi.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Pizza, PizzaDto>();
        CreateMap<PizzaForCreationDto, Pizza>();
    }
}