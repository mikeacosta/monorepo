using Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public interface IHouseRepository
{
    Task<List<HouseDto>> GetAllAsync();
}

public class HouseRepository : IHouseRepository
{
    private readonly AppDbContext _dbContext;
    
    public HouseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<HouseDto>> GetAllAsync()
    {
        return await _dbContext.Houses
            .Select(h => new HouseDto(h.Id, h.Address, h.Country, h.Price))
            .ToListAsync();
    }
}