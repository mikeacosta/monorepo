namespace CodePulse.API.Models;

public class CreateCategoryRequestDto
{
    public String Name { get; set; } = string.Empty;
    public String UrlHandle { get; set; } = string.Empty;
}