namespace Company.API.Models;

public class AddressDto
{
    public int Id { get; set; }
    
    public string Address1 { get; set; } = default!;
    
    public string? Address2 { get; set; }
    
    public string City { get; set; } = default!;
    
    public string? State { get; set; }
    
    public string? PostalCode { get; set; }
    
    public string Country { get; set; } = default!;
}