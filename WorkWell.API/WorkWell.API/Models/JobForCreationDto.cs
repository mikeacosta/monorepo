namespace WorkWell.API.Models;

public class JobForCreationDto
{
    public string Title { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Salary { get; set; }
    public CompanyDto Company { get; set; }    
}