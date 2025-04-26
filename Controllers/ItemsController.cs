using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPP_1.Data;
using webAPP_1.Models;
namespace webAPP_1.Controllers;

public class ItemsController:Controller
{
    private readonly WebAPP_1Contaxt _context;

    public ItemsController(WebAPP_1Contaxt context)
    {
        _context = context;
    }

    public  async  Task<IActionResult> Index()
        //async make the data flow is asynchronous
        //we added task of IAction results in 
        //it just will display All items in DataBase
    {
    
        var item =await  _context.Items.Include(s=>s.SerialNumber).ToListAsync();
        //make sure to import Microsoft.EntityFrameworkCore before 
        //adding await to item and make it to TolistAsync
        return View(item);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id", "Name", "Price")] Item item)
    {
        if (ModelState.IsValid)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        else
        {
            return View(item);

        }
    }

    [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }    
            return View(item);
        }
    public async Task<IActionResult> Edit(int id)
    {
        var item = await _context.Items.FirstOrDefaultAsync(x=>x.Id==id);
        return View(item);
    }

    
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Items.FirstOrDefaultAsync(x=>x.Id==id);
        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.Items.FindAsync(id);
        if (item != null)
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}