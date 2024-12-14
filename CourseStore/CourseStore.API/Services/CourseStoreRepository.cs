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

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await _context.Authors
            .Include(a => a.Courses).ToListAsync();
    }

    public async Task<Author?> GetAuthorAsync(Guid authorId)
    {
        if (authorId == Guid.Empty)
            throw new ArgumentNullException(nameof(authorId));
        
        return await _context.Authors.Include(a => a.Courses)
            .FirstOrDefaultAsync(a => a.Id == authorId);
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

    public void AddCourse(Guid authorId, Course course)
    {
        if (authorId == Guid.Empty || course == null)
            throw new ArgumentNullException(nameof(authorId));
        
        course.AuthorId = authorId;
        _context.Courses.Add(course);
    }

    public void AddAuthor(Author author)
    {
        _context.Authors.Add(author);
    }

    public async Task<bool> SaveAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }    
}