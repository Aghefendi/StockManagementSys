using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;

namespace StockManagementSys.Controllers
{
    public class UnitController : Controller
    {

       
        public IActionResult Index(string sortExpression="")
        {
            ViewData["SortParamName"] = "name";
            ViewData["SortParamDesc"] = "desciption";

            SortOrder sortOrder;
            string sortProperty;

            switch(sortExpression.ToLower()){

                case "name_desc":
                    sortOrder = SortOrder.Descending;
                    sortProperty = "name";
                    ViewData["SortParamName"] = "name";
                    break;
                case "desciption":
                    sortOrder = SortOrder.Ascending;
                    sortProperty="description";
                    ViewData["SortParamDesc"] = "description_desc";
                    break;
                case "desciption_desc":
                    sortOrder = SortOrder.Descending;
                    sortProperty = "description";
                    ViewData["SortParamDesc"] = "description";

                    break;
                default:
                    sortOrder = SortOrder.Ascending;
                    sortProperty = "name";
                    ViewData["SortParamName"] = "name_desc";
                    break;

            }
            

            List<Unit> units = _unitRepo.GetItems(sortProperty,sortOrder);//_context.Units.ToList();
            return View(units);
        }
       
        private IUnits _unitRepo;
        public UnitController( IUnits unitrepo)
        {
            
            _unitRepo = unitrepo;
        }

        public IActionResult Create()
        {
            Unit unit = new Unit();

            return View(unit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Unit unit)
        {


            try
            {
               unit= _unitRepo.Create(unit);

            }
            catch 
            {

                
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);

        }
        public IActionResult Edit(int id)
        {
            Unit unit = _unitRepo.GetUnit(id);
            return View(unit);

        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {


            try
            {
                unit= _unitRepo.Edit(unit);


            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            Unit unit = _unitRepo.GetUnit(Id);
            return View(unit);

        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {


            try
            {
               
                unit=_unitRepo.Delete(unit);

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }
     
      
    }
}
