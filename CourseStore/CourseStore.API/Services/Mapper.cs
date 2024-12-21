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
        var dto = new AuthorDto
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName
        };
        
        foreach (var course in author.Courses)
            dto.Courses.Add(ToCourseDto(course));
        
        return dto;
    }

    public Author ToAuthorEntity(AuthorForCreationDto dto)
    {
        var entity = new Author
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
        };

        foreach (var courseForCreationDto in dto.Courses)
            entity.Courses.Add(ToCourseEntity(courseForCreationDto));
        
        return entity;
    }

    public IEnumerable<Author> ToAuthorEntities(IEnumerable<AuthorForCreationDto> dtos)
    {
        return dtos.Select(dto => ToAuthorEntity(dto));
    }

    public IEnumerable<AuthorDto> ToAuthorsDtos(IEnumerable<Author> entities)
    {
        return entities.Select(a => ToAuthorDto(a));
    }
}