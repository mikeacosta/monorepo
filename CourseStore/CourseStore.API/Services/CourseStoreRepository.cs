using CourseStore.API.Data;
using CourseStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.API.Services;

public class CourseStoreRepository : ICourseStoreRepository
{
    private readonly AppDbContext _context;

    public CourseStoreRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync(Guid authorId)
    {
        if (authorId == Guid.Empty)
            throw new ArgumentNullException(nameof(authorId));
        
        return await _context.Courses
            .Where(c => c.AuthorId == authorId)
            .OrderBy(c => c.Title).ToListAsync();
    }

    public async Task<Course?> GetCourseAsync(Guid authorId, Guid courseId)
    {
        if (authorId == Guid.Empty || courseId == Guid.Empty)
            throw new ArgumentNullException(nameof(authorId));
        
        return await _context.Courses
            .Where(c => c.AuthorId == authorId && c.Id == courseId)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> AuthorExistsAsync(Guid authorId)
    {
        if (authorId == Guid.Empty)
            throw new ArgumentNullException(nameof(authorId));

        return await _context.Authors.AnyAsync(a => a.Id == authorId);
    }
}