using CodePulse.API.Data;
using CodePulse.API.Entities;

namespace CodePulse.API.Repositories;

public class BlogPostsRepository : IBlogPostsRepository
{
    private readonly AppDbContext _context;

    public BlogPostsRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<BlogPost> CreateAsync(BlogPost blogPost)
    {
        await _context.BlogPosts.AddAsync(blogPost);
        await _context.SaveChangesAsync();
        return blogPost;
    }
}