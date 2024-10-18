using CodePulse.API.Entities;

namespace CodePulse.API.Repositories;

public interface IBlogPostsRepository
{
    Task<BlogPost> CreateAsync(BlogPost blogPost);
    
    Task<IEnumerable<BlogPost>> GetAllAsync();

    Task<BlogPost?> GetByIdAsync(Guid id);
    
    Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);

    Task<BlogPost?> UpdateAsync(BlogPost blogPost);

    Task<BlogPost?> DeleteAsync(Guid id);
}