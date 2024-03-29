using CarvedRock.Admin.Logic;
using CarvedRock.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.Admin.Controllers;

public class ProductsController : Controller
{
    private readonly IProductLogic _logic;
    private readonly ILogger<ProductsController> _logger;
    
    public List<ProductModel> Products { get; set; }
    
    public ProductsController(IProductLogic logic, ILogger<ProductsController> logger)
    {
        _logic = logic;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _logic.GetAllProducts();
        return View(products);
    }
    
    public async Task<IActionResult> Details(int id)
    {
        var product = await _logic.GetProductById(id);
        if (product is not null)
            return View(product);
        
        _logger.LogInformation($"Details not found for id {id}");
        return View("NotFound");
    }   
    
    public async Task<IActionResult> Create()
    {
        var model = await _logic.InitializeProductModel();
        return View(model);
    }
    
    // POST: ProductsData/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductModel product)
    {
        if (ModelState.IsValid)
        {
            await _logic.AddNewProduct(product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }    
    
    // GET: ProductsData/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            _logger.LogInformation("No id passed for edit");
            return View("NotFound");
        }

        var productModel = await _logic.GetProductById(id.Value);
        if (productModel == null)
        {
            _logger.LogInformation($"Edit details not found for id {id}");
            return View("NotFound");
        }

        await _logic.GetAvailableCategories(productModel);
        return View(productModel);
    }
    
    // POST: ProductsData/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProductModel product)
    {
        if (id != product.Id) 
            return NotFound();

        if (ModelState.IsValid)
        {
            await _logic.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }    
    
    // GET: ProductsData/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) 
            return NotFound();

        var productModel = await _logic.GetProductById(id.Value);
        if (productModel == null) 
            return NotFound();

        return View(productModel);
    }

    // POST: ProductsData/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _logic.RemoveProduct(id);
        return RedirectToAction(nameof(Index));
    }   
}