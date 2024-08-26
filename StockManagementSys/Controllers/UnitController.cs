using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Models;

namespace StockManagementSys.Controllers
{
    public class UnitController : Controller
    {

       
        public IActionResult Index()
        {

            List<Unit> units=_context.Units.ToList();
            return View(units);
        }
        private readonly InventoryContext _context;
        public UnitController(InventoryContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            Unit unit = new Unit();

            return View(unit);
        }
        [HttpPost]
        public IActionResult Create(Unit unit)
        {


            try
            {
                _context.Units.Add(unit);
                _context.SaveChanges();

            }
            catch 
            {

                
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int Id)
        {
            Unit unit = GetUnit(Id);
            return View(unit);

        }
        public IActionResult Edit(int Id)
        {
            Unit unit = GetUnit(Id);
            return View(unit);

        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {


            try
            {
                _context.Units.Attach(unit);
                _context.Entry(unit).State = EntityState.Modified;
                _context.SaveChanges();


            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            Unit unit = GetUnit(Id);
            return View(unit);

        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {


            try
            {
                _context.Units.Attach(unit);
                _context.Entry(unit).State = EntityState.Deleted;
                _context.SaveChanges();


            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }
        private Unit GetUnit(int id)
        {
            Unit unit = _context.Units.Where(x => x.Id == id).FirstOrDefault();
            return unit;

        }
      
    }
}
