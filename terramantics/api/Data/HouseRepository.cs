using api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public interface IHouseRepository
{
    Task<List<HouseDto>> GetAll();
    Task<HouseDetailDto?> Get(int id);
}

public class HouseRepository : IHouseRepository
{
    private readonly HouseDbContext _context;
    
    public HouseRepository(HouseDbContext context)
    {
        _context = context;
    }

    public async Task<List<HouseDto>> GetAll()
    {
        return await _context.Houses.Select(h =>
            new HouseDto(h.Id, h.Address, h.Country, h.Price)).ToListAsync();
    }
    
    public async Task<HouseDetailDto?> Get(int id)
    {
        var entity = await _context.Houses.SingleOrDefaultAsync(h => h.Id == id);
        if (entity == null)
            return null;
        
        return new HouseDetailDto(entity.Id,
            entity.Address,
            entity.Country,
            entity.Description,
            entity.Price,
            entity.Photo);
    }
}