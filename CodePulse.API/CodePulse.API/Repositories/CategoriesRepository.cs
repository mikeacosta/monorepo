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

    public async Task<Category> UpdateAsync(Category category)
    {
        _context.Set<Category>().Update(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> DeleteAsync(Guid id)
    {
        var entity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (entity is null)
            return null;

        _context.Categories.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}