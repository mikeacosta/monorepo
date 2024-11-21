using Company.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Company.API.Services;

public class CompaniesRepository : ICompaniesRepository
{
    private readonly AppDbContext _context;
    
    public CompaniesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Entities.Company>> GetCompaniesAsync()
    {
        return await _context.Companies
            .Include(c => c.Address)
            .OrderBy(c => c.Name).ToListAsync();
    }

    public async Task<Entities.Company?> GetCompanyAsync(int id)
    {
        return await _context.Companies.Where(c => c.Id == id)
            .Include(c => c.Address)
            .FirstOrDefaultAsync();
    }
}