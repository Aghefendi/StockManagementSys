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
    public class CategoryController : Controller
    {
        private ICategory _categoryrepo;
        public CategoryController(ICategory categoryrepo)
        {

            _categoryrepo = categoryrepo;
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

            List<Category> items = _categoryrepo.GetItems(sortModel.SortProperty, sortModel.SortOrder, SearchText, pg, pageSize);//_context.Units.ToList();
            int totRecors = ((PaginatedList<Category>)items).TotalRecords;

            var pager = new PagerModel(totRecors, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;
            return View(items);
        }

        

        public IActionResult Create()
        {
            Category category = new Category();

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {


            try
            {
                category = _categoryrepo.Create(category);

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            Category category = _categoryrepo.GetItem(id);
            return View(category);

        }
        public IActionResult Edit(int id)
        {
            Category category = _categoryrepo.GetItem(id);
            return View(category);

        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {


            try
            {
                category = _categoryrepo.Edit(category);


            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            Category category = _categoryrepo.GetItem(Id);
            return View(category);

        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {


            try
            {

                category = _categoryrepo.Delete(category);

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }


    }
}
