using HoopsPlayersAPI.Models;

namespace HoopsPlayersAPI.Logic;

public interface IPlayerLogic
{
    Task<List<HoopsPlayerDto>> GetAllPlayers();
    Task<HoopsPlayerDto?> GetPlayerById(int id);
    Task<HoopsPlayerDto> AddNewPlayer(CreateHoopsPlayerDto playerToAdd);
    Task UpdatePlayer(int id, UpdateHoopsPlayerDto playerToUpdate);
    Task RemovePlayer(int id);
    Task<bool> PlayerExists(int id);
}