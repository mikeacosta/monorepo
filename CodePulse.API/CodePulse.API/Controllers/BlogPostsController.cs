using CodePulse.API.Entities;
using CodePulse.API.Models;
using CodePulse.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers;

[ApiController]
[Route("api/blogposts")]
public class BlogPostsController : ControllerBase
{
    private readonly IBlogPostsRepository _repo;
    
    public BlogPostsController(IBlogPostsRepository repo)
    {
        _repo = repo;
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
            IsVisible = requestDto.IsVisible
        };

        await _repo.CreateAsync(blogPost);

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
            IsVisible = blogPost.IsVisible
        };
        
        return Created(String.Empty, dto);
    }
    
    // GET: /api/blogposts
    [HttpGet]
    public async Task<IActionResult> GetAllBlogPosts()
    {
        var blogPosts = await _repo.GetAllAsync();
        
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
                IsVisible = blogPost.IsVisible
            });
        }

        return Ok(result);
    }
}