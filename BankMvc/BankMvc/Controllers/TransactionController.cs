using BankMvc.Helpers;
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
        if (id == 0)
            return View(new TransactionModel());
        else
        {
            var transactionModel = await _context.Transactions.FindAsync(id);
            if (transactionModel == null)
            {
                return NotFound();
            }
            return View(transactionModel);
        }
    }

    // POST: Transaction/AddOrEdit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddOrEdit(int id,
        [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTCode,Amount,Date")]
        TransactionModel transactionModel)
    {
        if (!ModelState.IsValid)
            return Json(new { isValid = false, html = RenderHelper.RenderRazorViewToString(this, "AddOrEdit", transactionModel) });

        if (id == 0)
        {
            transactionModel.Date = DateTime.Now;
            _context.Add(transactionModel);
            await _context.SaveChangesAsync();
        }
        else
        {
            try
            {
                _context.Update(transactionModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (TransactionModelExists(transactionModel.TransactionId))
                    throw;
                
                return NotFound();
            }
        }

        return Json(new { isValid = true, html = RenderHelper.RenderRazorViewToString(this, "_ViewAll", _context.Transactions.ToList()) });
    }
    
    // POST: Transaction/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var transactionModel = await _context.Transactions.FindAsync(id);
        _context.Transactions.Remove(transactionModel);
        await _context.SaveChangesAsync();
        return Json(new { html = RenderHelper.RenderRazorViewToString(this, "_ViewAll", _context.Transactions.ToList()) });
    }
    
    private bool TransactionModelExists(int id)
    {
        return _context.Transactions.Any(e => e.TransactionId == id);
    }
}