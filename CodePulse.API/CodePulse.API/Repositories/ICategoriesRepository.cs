using CodePulse.API.Entities;

namespace CodePulse.API.Repositories;

public interface ICategoriesRepository
{
    Task<Category> CreateAsync(Category category);
}