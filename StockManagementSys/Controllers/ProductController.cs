using CodeByStudent.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;
using SortOrder = CodeByStudent.Tools.SortOrder;





namespace StockManagementSys.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IUnits _unitRepo;
        private readonly IProduct _productRepo;
        public ProductController(IProduct productrepo, IUnits unitRepo)
        {

            _productRepo = productrepo;
            _unitRepo = unitRepo;
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
            sortModel.AddColumn("Code");
            sortModel.AddColumn("name");
            sortModel.AddColumn("description");
            sortModel.AddColumn("Cost");
            sortModel.AddColumn("Price");
            sortModel.AddColumn("Unit");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            List<Product> products = _productRepo.GetItems(sortModel.SortProperty, sortModel.SortOrder, SearchText);//_context.Units.ToList();
            var pager = new PagerModel(products.Count, pg, pageSize);

            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;
            products = products.Skip((pg - 1) * pageSize).Take(pageSize).ToList();



            return View(products);
        }


        public IActionResult Create()
        {
            Product product = new Product();
            ViewBag.Units = GetUnits();

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {


            try
            {
                product = _productRepo.Create(product);

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(string id)
        {
            Product product = _productRepo.GetItem(id);
            return View(product);

        }
        public IActionResult Edit(string id)
        {
            Product product = _productRepo.GetItem(id);
            return View(product);

        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {


            try
            {
                product = _productRepo.Edit(product);


            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string Id)
        {
            Product product = _productRepo.GetItem(Id);
            return View(product);

        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {


            try
            {

                product = _productRepo.Delete(product);

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetUnits()
        {

            var IsUnits=new List<SelectListItem>();

            List<Unit> units = _unitRepo.GetItems("Name", SortOrder.Ascending);
           IsUnits=units.Select(ut=>new SelectListItem()
           {
             Value=ut.Id.ToString(),
             Text=ut.Name


           }).ToList(); 

            var defItem=new SelectListItem()
            {
                Value="",
                Text="----Select Unit----"


            };

            IsUnits.Insert(0,defItem);


            return IsUnits;
        }


    }
}
