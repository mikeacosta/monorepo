using BethanysPieShop.Data;
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Repositories;

public class PieRepository : IPieRepository
{
    private readonly BethanysPieShopDbContext _dbContext;

    public PieRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
    {
        _dbContext = bethanysPieShopDbContext;
    }
    
    public IEnumerable<Pie> AllPies { 
        get
        {
            return _dbContext.Pies.Include(p => p.Category);
        } 
    }
    
    public IEnumerable<Pie> PiesOfTheWeek { 
        get
        {
            return _dbContext.Pies.Include(p => p.Category)
                .Where(p => p.IsPieOfTheWeek);
        } 
    }

    public Pie? GetPieById(int pieId)
    {
        return _dbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
    }
}