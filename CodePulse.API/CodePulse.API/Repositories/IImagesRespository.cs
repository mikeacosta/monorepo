using System.Net;
using CodePulse.API.Entities;

namespace CodePulse.API.Repositories;

public interface IImagesRespository
{
    Task<BlogImage> Upload(IFormFile file, BlogImage image);
}