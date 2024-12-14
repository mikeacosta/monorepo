using CourseStore.API.Entities;
using CourseStore.API.Models;

namespace CourseStore.API.Services;

public interface IMapper
{
    CourseDto ToCourseDto(Course course);
    Course ToCourseEntity(CourseForCreationDto dto);
    AuthorDto ToAuthorDto(Author author);
    Author ToAuthorEntity(AuthorForCreationDto dto);
}