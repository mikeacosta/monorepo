using CodePulse.API.Entities;

namespace CodePulse.API.Repositories;

public interface ICategoriesRepository
{
    Task<Category> CreateAsync(Category category);

    Task<IEnumerable<Category>> GetAllAsync();

    Task<Category?> GetByIdAsync(Guid id);
    
    Task<Category> UpdateAsync(Category category);
    
    Task<Category?> DeleteAsync(Guid id);
}