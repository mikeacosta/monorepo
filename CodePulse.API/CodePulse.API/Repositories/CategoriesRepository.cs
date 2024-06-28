using CodePulse.API.Data;
using CodePulse.API.Entities;

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
}