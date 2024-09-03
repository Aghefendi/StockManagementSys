using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Models.StockManagementSys.Models;

namespace StockManagementSys.Controllers
{
    public class InwardsController : Controller
    {
        private readonly InventoryContext _context;

        public InwardsController(InventoryContext context)
        {
            _context = context;
        }

        // GET: Inwards
        public async Task<IActionResult> Index()
        {
            var inventoryContext = _context.Inwards.Include(i => i.Supplier);
            return View(await inventoryContext.ToListAsync());
        }

        // GET: Inwards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inwards == null)
            {
                return NotFound();
            }

            var inward = await _context.Inwards
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inward == null)
            {
                return NotFound();
            }

            return View(inward);
        }

        // GET: Inwards/Create
        public IActionResult Create()
        {
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Code");
            return View();
        }

        // POST: Inwards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InwardNumber,SupplierId,InwardDate,Remarks")] Inward inward)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inward);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Code", inward.SupplierId);
            return View(inward);
        }

        // GET: Inwards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inwards == null)
            {
                return NotFound();
            }

            var inward = await _context.Inwards.FindAsync(id);
            if (inward == null)
            {
                return NotFound();
            }
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Code", inward.SupplierId);
            return View(inward);
        }

        // POST: Inwards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InwardNumber,SupplierId,InwardDate,Remarks")] Inward inward)
        {
            if (id != inward.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inward);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InwardExists(inward.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Code", inward.SupplierId);
            return View(inward);
        }

        // GET: Inwards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inwards == null)
            {
                return NotFound();
            }

            var inward = await _context.Inwards
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inward == null)
            {
                return NotFound();
            }

            return View(inward);
        }

        // POST: Inwards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inwards == null)
            {
                return Problem("Entity set 'InventoryContext.Inwards'  is null.");
            }
            var inward = await _context.Inwards.FindAsync(id);
            if (inward != null)
            {
                _context.Inwards.Remove(inward);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InwardExists(int id)
        {
          return (_context.Inwards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
