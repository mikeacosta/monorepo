using BankMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankMvc.Controllers;

public class TransactionController : Controller
{
    private readonly TransactionDbContext _context;

    public TransactionController(TransactionDbContext context)
    {
        _context = context;
    }
    
    // GET: Transaction
    public async Task<IActionResult> Index()
    {
        return View(await _context.Transactions.ToListAsync());
    }
    
    // GET: Transaction/AddOrEdit(Insert)
    // GET: Transaction/AddOrEdit/5(Update)
    public async Task<IActionResult> AddOrEdit(int id = 0)
    {
        return null;
    }
    

    // GET: Transaction/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        return null;
    }    
}