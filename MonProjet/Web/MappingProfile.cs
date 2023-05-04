using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace Web;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Owner, OwnerDto>();
        
        CreateMap<Account, AccountDto>();
    }
}