using Company.API.Entities;

namespace Company.API.Models;

public class CompanyDto
{
    public int Id { get; set; }

    public string Name { get; set; } = String.Empty;
    
    public AddressDto? Address { get; set; }
    
    public ICollection<ContactDto> Contacts { get; set; }
        = new List<ContactDto>();    
}