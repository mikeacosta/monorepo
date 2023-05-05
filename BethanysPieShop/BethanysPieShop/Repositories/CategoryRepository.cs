using BethanysPieShop.Data;
using BethanysPieShop.Models;

namespace BethanysPieShop.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly BethanysPieShopDbContext _dbContext;
    
    public CategoryRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
    {
        _dbContext = bethanysPieShopDbContext;
    }

    public IEnumerable<Category> AllCategories 
        => _dbContext.Categories.OrderBy(c => c.CategoryName);
}