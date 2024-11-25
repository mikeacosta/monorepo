using AutoMapper;
using Company.API.Entities;
using Company.API.Models;

namespace Company.API.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Entities.Company, CompanyDto>();
        CreateMap<CompanyDto, Entities.Company>();
        CreateMap<Address, AddressDto>();
        CreateMap<AddressDto, Address>();
        CreateMap<Contact, ContactDto>();
        CreateMap<ContactDto, Contact>();
    }
}