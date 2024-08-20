using CodePulse.API.Entities;
using CodePulse.API.Models;
using CodePulse.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers;

[ApiController]
[Route("api/blogposts")]
public class BlogPostsController : ControllerBase
{
    private readonly IBlogPostsRepository _blogPostsRepo;
    private readonly ICategoriesRepository _categoriesRepo;
    
    public BlogPostsController(IBlogPostsRepository blogPostsRepo, ICategoriesRepository categoriesRepo)
    {
        _blogPostsRepo = blogPostsRepo;
        _categoriesRepo = categoriesRepo;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDto requestDto)
    {
        var blogPost = new BlogPost
        {
            Id = new Guid(),
            Title = requestDto.Title,
            ShortDescription = requestDto.ShortDescription,
            Content = requestDto.Content,
            FeaturedImageUrl = requestDto.FeaturedImageUrl,
            UrlHandle = requestDto.UrlHandle,
            PublishedDate = requestDto.PublishedDate,
            Author = requestDto.Author,
            IsVisible = requestDto.IsVisible,
            Categories = new List<Category>()
        };

        foreach (var id in requestDto.Categories)
        {
            var cat = await _categoriesRepo.GetByIdAsync(id);
            if (cat is not null)
                blogPost.Categories.Add(cat);
        }

        await _blogPostsRepo.CreateAsync(blogPost);

        var dto = new BlogPostDto
        {
            Id = blogPost.Id,
            Title = blogPost.Title,
            ShortDescription = blogPost.ShortDescription,
            Content = blogPost.Content,
            FeaturedImageUrl = blogPost.FeaturedImageUrl,
            UrlHandle = blogPost.UrlHandle,
            PublishedDate = blogPost.PublishedDate,
            Author = blogPost.Author,
            IsVisible = blogPost.IsVisible,
            Categories = blogPost.Categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                UrlHandle = c.UrlHandle
            }).ToList()
        };
    
        return Created(String.Empty, dto);

    }
    
    // GET: /api/blogposts
    [HttpGet]
    public async Task<IActionResult> GetAllBlogPosts()
    {
        var blogPosts = await _blogPostsRepo.GetAllAsync();
        
        var result = new List<BlogPostDto>();
        foreach (var blogPost in blogPosts)
        {
            result.Add(new BlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                ShortDescription = blogPost.ShortDescription,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                UrlHandle = blogPost.UrlHandle,
                PublishedDate = blogPost.PublishedDate,
                Author = blogPost.Author,
                IsVisible = blogPost.IsVisible,
                Categories = blogPost.Categories.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    UrlHandle = c.UrlHandle
                }).ToList()
            });
        }

        return Ok(result);
    }
    
    // GET: /api/blogposts/{id}
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetBlogPostById([FromRoute]Guid id)
    {
        var blogPost = await _blogPostsRepo.GetByIdAsync(id);
        if (blogPost is null)
            return NotFound();

        var response = new BlogPostDto
        {
            Id = blogPost.Id,
            Title = blogPost.Title,
            ShortDescription = blogPost.ShortDescription,
            Content = blogPost.Content,
            FeaturedImageUrl = blogPost.FeaturedImageUrl,
            UrlHandle = blogPost.UrlHandle,
            PublishedDate = blogPost.PublishedDate,
            Author = blogPost.Author,
            IsVisible = blogPost.IsVisible,
            Categories = blogPost.Categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                UrlHandle = c.UrlHandle
            }).ToList()
        };

        return Ok(response);
    }
    
    // PUT: /api/blogposts/{id}
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> EditBlogPost([FromRoute] Guid id, [FromBody] UpdateBlogPostRequestDto requestDto)
    {
        var entity = await _blogPostsRepo.GetByIdAsync(id);
        if (entity is null)
            return NotFound();

        entity.Title = requestDto.Title;
        entity.UrlHandle = requestDto.UrlHandle;
        entity.ShortDescription = requestDto.ShortDescription;
        entity.Content = requestDto.Content;
        entity.FeaturedImageUrl = requestDto.FeaturedImageUrl;
        entity.PublishedDate = requestDto.PublishedDate;
        entity.Author = requestDto.Author;
        entity.IsVisible = requestDto.IsVisible;
        entity.Categories = new List<Category>();

        foreach (var guid in requestDto.Categories)
        {
            var existingCategory = await _categoriesRepo.GetByIdAsync(guid);
            if (existingCategory is null)
                continue;
            
            entity.Categories.Add(existingCategory);
        }

        var updated = await _blogPostsRepo.UpdateAsync(entity);
        
        var result = new BlogPostDto
        {
            Id = updated.Id,
            Title = updated.Title,
            ShortDescription = updated.ShortDescription,
            Content = updated.Content,
            FeaturedImageUrl = updated.FeaturedImageUrl,
            UrlHandle = updated.UrlHandle,
            PublishedDate = updated.PublishedDate,
            Author = updated.Author,
            IsVisible = updated.IsVisible,
            Categories = updated.Categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                UrlHandle = c.UrlHandle
            }).ToList()
        };

        return Ok(result);        
    }
}