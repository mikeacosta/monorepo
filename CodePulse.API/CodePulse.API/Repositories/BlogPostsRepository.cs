using CodePulse.API.Data;
using CodePulse.API.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
        return await _context.BlogPosts.Include(b => b.Categories).ToListAsync();
    }

    public async Task<BlogPost?> GetByIdAsync(Guid id)
    {
        return await _context.BlogPosts.Include(b => b.Categories)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}