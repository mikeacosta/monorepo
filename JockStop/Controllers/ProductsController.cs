using JockStop.Models;
using Microsoft.AspNetCore.Mvc;

namespace JockStop.Controllers;

[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly DataContext _context;

    public ProductsController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IEnumerable<Product> GetProducts()
    {
        return _context.Products;
    }
    
    [HttpGet("{id}")]
    public Product? GetProduct(long id)
    {
        return _context.Products.Find(id);
    }    
}