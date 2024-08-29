using CodeByStudent.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;
using SortOrder = CodeByStudent.Tools.SortOrder;





namespace StockManagementSys.Controllers
{
    public class UnitController : Controller
    {

        private SortModel ApplySort(string sortExpression)


        {
            ViewData["SortParamName"] = "name";
            ViewData["SortParamDesc"] = "description";

            ViewData["SortIconName"] = "";
            ViewData["SortIconDesc"] = "";

            //SortOrder sortOrder;
            //string sortProperty;

            SortModel sortModel = new SortModel();

            switch (sortExpression.ToLower())
            {

                case "name_desc":
                    sortModel.SortOrder = SortOrder.Descending;
                    sortModel.SortProperty = "name";
                    ViewData["SortParamName"] = "name";
                    ViewData["SortIconName"] = "fa fa-arrow-up";
                    break;
                case "description":
                    sortModel.SortOrder = SortOrder.Ascending;
                    sortModel.SortProperty = "description";
                    ViewData["SortParamDesc"] = "description_desc";
                    ViewData["SortIconDesc"] = "fa fa-arrow-down";
                    break;
                case "description_desc":
                    sortModel.SortOrder = SortOrder.Descending;
                    sortModel.SortProperty = "description";
                    ViewData["SortParamDesc"] = "description";
                    ViewData["SortIconDesc"] = "fa fa-arrow-up";



                    break;
                default:
                    sortModel.SortOrder = SortOrder.Ascending;
                    sortModel.SortProperty = "name";
                    ViewData["SortIconName"] = "fa fa-arrow-down";
                    ViewData["SortParamName"] = "name_desc";

                    break;

            }

            return sortModel;


        }

        public IActionResult Index(string sortExpression = "",string SearchText="")
            {

                SortModel sortModel =new SortModel();
            sortModel.AddColumn("name");
            sortModel.AddColumn("description");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            




                List<Unit> units = _unitRepo.GetItems(sortModel.SortProperty, sortModel.SortOrder , SearchText );  //_context.Units.ToList();
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
