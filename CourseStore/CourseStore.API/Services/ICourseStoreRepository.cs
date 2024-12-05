using CourseStore.API.Entities;

namespace CourseStore.API.Services;

public interface ICourseStoreRepository
{
    Task<IEnumerable<Course>> GetCoursesAsync(Guid authorId);
    Task<Course?> GetCourseAsync(Guid authorId, Guid courseId);
    Task<bool> AuthorExistsAsync(Guid authorId);
}