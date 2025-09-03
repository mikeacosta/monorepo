using System.Text.Json.Serialization;

namespace WorkWell.API.Models;

public class JobDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Salary { get; set; }
    [JsonPropertyName("company")]
    public CompanyDto CompanyDto { get; set; }
}