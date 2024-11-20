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
        return await _context.Companies.OrderBy(c => c.Name).ToListAsync();
    }

    public async Task<Entities.Company?> GetCompanyAsync(int id)
    {
        return await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);
    }
}