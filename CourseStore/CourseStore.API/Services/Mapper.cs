using CourseStore.API.Entities;
using CourseStore.API.Models;

namespace CourseStore.API.Services;

public class Mapper : IMapper
{
    public CourseDto ToCourseDto(Course course)
    {
        return new CourseDto
        {
            Id = course.Id,
            Title = course.Title,
            Description = course.Description
        };
    }

    public Course ToCourseEntity(CourseForCreationDto dto)
    {
        return new Course
        {
            Title = dto.Title,
            Description = dto.Description
        };
    }

    public AuthorDto ToAuthorDto(Author author)
    {
        return new AuthorDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName
        };
    }
}