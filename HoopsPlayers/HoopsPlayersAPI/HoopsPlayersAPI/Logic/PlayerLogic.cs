using AutoMapper;
using HoopsPlayersAPI.Entities;
using HoopsPlayersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HoopsPlayersAPI.Logic;

public class PlayerLogic : IPlayerLogic
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly ILogger<PlayerLogic> _logger;
    
    public PlayerLogic(DataContext dataContext,
        IMapper mapper,
        ILogger<PlayerLogic> logger)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<List<HoopsPlayerDto>> GetAllPlayers()
    {
        _logger.LogInformation("Getting all players");
        var entities = await _dataContext.HoopsPlayers.OrderBy(p => p.Id).ToListAsync();
        return _mapper.Map<List<HoopsPlayerDto>>(entities);
    }

    public async Task<HoopsPlayerDto?> GetPlayerById(int id)
    {
        _logger.LogInformation($"Getting player for id {id}");
        var entity = await _dataContext.HoopsPlayers.FirstOrDefaultAsync(p => p.Id == id);
        return _mapper.Map<HoopsPlayerDto>(entity);
    }

    public async Task<HoopsPlayerDto> AddNewPlayer(CreateHoopsPlayerDto playerToAdd)
    {
        var entity = _mapper.Map<HoopsPlayer>(playerToAdd);
        await _dataContext.AddAsync(entity);
        await _dataContext.SaveChangesAsync();
        return _mapper.Map<HoopsPlayerDto>(entity);
    }

    public async Task UpdatePlayer(int id, UpdateHoopsPlayerDto playerToUpdate)
    {
        var playerEntity = await _dataContext.HoopsPlayers.FindAsync(id);
        if (playerEntity is null) return;
        _dataContext.Update(_mapper.Map(playerToUpdate, playerEntity));
        await _dataContext.SaveChangesAsync();
    }
    
    public async Task RemovePlayer(int id)
    {
        var playerEntity = await _dataContext.HoopsPlayers.FindAsync(id);
        if (playerEntity is null) return;
        _dataContext.HoopsPlayers.Remove(playerEntity);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<bool> PlayerExists(int id)
    {
        return await _dataContext.HoopsPlayers.FindAsync(id) is not null 
            ? true 
            : false;
    }
}