using CodePulse.API.Data;
using CodePulse.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly AppDbContext _context;
    
    public CategoriesRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Category> CreateAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
    }
}