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
    
    [HttpPost]
    public void SaveProduct([FromBody] Product product) {
        _context.Products.Add(product);
        _context.SaveChanges();
    }  
    
    [HttpPut]
    public void UpdateProduct([FromBody] Product product) {
        _context.Products.Update(product);
        _context.SaveChanges();
    }
    
    [HttpDelete("{id}")]
    public void DeleteProduct(long id) {
        _context.Products.Remove(new Product() { ProductId = id });
        _context.SaveChanges();
    }
}