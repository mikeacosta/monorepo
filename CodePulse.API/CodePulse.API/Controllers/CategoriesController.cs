using CodePulse.API.Data;
using CodePulse.API.Entities;
using CodePulse.API.Models;
using CodePulse.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesRepository _repo;
    
    public CategoriesController(ICategoriesRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto requestDto)
    {
        var category = new Category()
        {
            Id = new Guid(),
            Name = requestDto.Name,
            UrlHandle = requestDto.UrlHandle
        };

        await _repo.CreateAsync(category);
        
        var dto = new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle
        };

        return Created(String.Empty, dto);
    }
    
    // GET: /api/categories
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _repo.GetAllAsync();

        var result = new List<CategoryDto>();
        foreach (var category in categories)
        {
            result.Add(new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            });
        }

        return Ok(result);
    }
    
    // GET: /api/categories/{id}
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
    {
        var category = await _repo.GetByIdAsync(id);
        if (category is null)
            return NotFound();

        var dto = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            UrlHandle = category.UrlHandle
        };

        return Ok(dto);
    }    
}