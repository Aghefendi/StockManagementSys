using CodeByStudent.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;

namespace StockManagementSys.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {


        private ISupplier _supprepo;
        public SupplierController(ISupplier supprepo)
        {

            _supprepo = supprepo;
        }
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

        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {

            SortModel sortModel = new SortModel();
            sortModel.AddColumn("name");
            sortModel.AddColumn("description");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            List<Supplier> items = _supprepo.GetItems(sortModel.SortProperty, sortModel.SortOrder, SearchText, pg, pageSize);//_context.Units.ToList();
            int totRecors = ((PaginatedList<Supplier>)items).TotalRecords;

            var pager = new PagerModel(totRecors, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;
            return View(items);
        }



        public IActionResult Create()
        {
            Supplier Brand = new Supplier();

            return View(Brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Supplier Brand)
        {


            try
            {
                Brand = _supprepo.Create(Brand);

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            Supplier Brand = _supprepo.GetItem(id);
            return View(Brand);

        }
        public IActionResult Edit(int id)
        {
            Supplier Brand = _supprepo.GetItem(id);
            return View(Brand);

        }

        [HttpPost]
        public IActionResult Edit(Supplier Brand)
        {


            try
            {
                Brand = _supprepo.Edit(Brand);


            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            Supplier Brand = _supprepo.GetItem(Id);
            return View(Brand);

        }

        [HttpPost]
        public IActionResult Delete(Supplier Brand)
        {


            try
            {

                Brand = _supprepo.Delete(Brand);

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }

    }
}
