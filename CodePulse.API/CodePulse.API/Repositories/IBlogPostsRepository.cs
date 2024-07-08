using CodePulse.API.Entities;

namespace CodePulse.API.Repositories;

public interface IBlogPostsRepository
{
    Task<BlogPost> CreateAsync(BlogPost blogPost);
}