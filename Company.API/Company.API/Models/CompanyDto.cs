using Company.API.Entities;

namespace Company.API.Models;

public class CompanyDto
{
    public int Id { get; set; }

    public string Name { get; set; } = String.Empty;
    
    public Address? Address { get; set; }
    
    public ICollection<Contact> Contacts { get; set; }
        = new List<Contact>();    
}