using CodePulse.API.Entities;

namespace CodePulse.API.Repositories;

public interface ICategoriesRepository
{
    Task<Category> CreateAsync(Category category);

    Task<IEnumerable<Category>> GetAllAsync();
}