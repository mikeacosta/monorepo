using CourseStore.API.Entities;

namespace CourseStore.API.Services;

public interface ICourseStoreRepository
{
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Author?> GetAuthorAsync(Guid authorId);
    Task<IEnumerable<Author>> GetAuthorsAsync(IEnumerable<Guid> authorIds);
    Task<IEnumerable<Course>> GetCoursesAsync(Guid authorId);
    Task<Course?> GetCourseAsync(Guid authorId, Guid courseId);
    Task<bool> AuthorExistsAsync(Guid authorId);
    void AddCourse(Guid authorId, Course course);
    void AddAuthor(Author author);
    Task<bool> SaveAsync();
}