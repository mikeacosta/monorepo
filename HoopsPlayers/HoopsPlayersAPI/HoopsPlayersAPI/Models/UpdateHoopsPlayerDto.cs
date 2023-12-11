namespace HoopsPlayersAPI.Models;

public class UpdateHoopsPlayerDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Team { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}