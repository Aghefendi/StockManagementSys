using CodeByStudent.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;
using SortOrder = CodeByStudent.Tools.SortOrder;





namespace StockManagementSys.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        private IBrand _brandrepo;
        public BrandController(IBrand brandrepo)
        {

            _brandrepo = brandrepo;
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

            List<Brand> items = _brandrepo.GetItems(sortModel.SortProperty, sortModel.SortOrder, SearchText, pg, pageSize);//_context.Units.ToList();
            int totRecors = ((PaginatedList<Brand>)items).TotalRecords;

            var pager = new PagerModel(totRecors, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;
            return View(items);
        }



        public IActionResult Create()
        {
            Brand Brand = new Brand();

            return View(Brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Brand Brand)
        {


            try
            {
                Brand = _brandrepo.Create(Brand);

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            Brand Brand = _brandrepo.GetItem(id);
            return View(Brand);

        }
        public IActionResult Edit(int id)
        {
            Brand Brand = _brandrepo.GetItem(id);
            return View(Brand);

        }

        [HttpPost]
        public IActionResult Edit(Brand Brand)
        {


            try
            {
                Brand = _brandrepo.Edit(Brand);


            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            Brand Brand = _brandrepo.GetItem(Id);
            return View(Brand);

        }

        [HttpPost]
        public IActionResult Delete(Brand Brand)
        {


            try
            {

                Brand = _brandrepo.Delete(Brand);

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }


    }
}
