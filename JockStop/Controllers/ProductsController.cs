using JockStop.Models;
using Microsoft.AspNetCore.Mvc;

namespace JockStop.Controllers;

[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(DataContext context, ILogger<ProductsController> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    [HttpGet]
    public IEnumerable<Product> GetProducts()
    {
        return _context.Products;
    }
    
    [HttpGet("{id}")]
    public Product? GetProduct(long id)
    {
        _logger.LogDebug("GetProduct action invoked");
        return _context.Products.Find(id);
    }    
}