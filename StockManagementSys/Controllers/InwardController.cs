using CodeByStudent.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;

namespace StockManagementSys.Controllers
{
    [Authorize]
    public class InwardController : Controller
    {


        private IInward _repo;
        private IProduct _productrepo;
        private ISupplier _supplierrepo;
        public InwardController(IInward repo, IProduct productrepo, ISupplier supplierrepo)
        {

            _repo = repo;
            _productrepo = productrepo;
            _supplierrepo = supplierrepo;
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

            PaginatedList<Inward> items = _repo.GetItems(sortModel.SortProperty, sortModel.SortOrder, SearchText, pg, pageSize);//_context.Units.ToList();
            int totRecors = ((PaginatedList<Inward>)items).TotalRecords;

            var pager = new PagerModel(totRecors, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;
            TempData["CurrentPage"] = pg;

            return View(items);
        }



        public IActionResult Create()
        {
            Inward items = new Inward();
            items.InwardDetails.Add(new InwardDetail()
            {

                Id = 1,
            });
            ViewBag.ProductList = GetProduct();
            ViewBag.SupplierList = GetSupplier();

            return View(items);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Inward item)
        {
            bool bolret = false;
            try
            {
                bolret = _repo.Create(item);

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            Inward item = _repo.GetItem(id);
            return View(item);

        }
        public IActionResult Edit(int id)
        {
            Inward item = _repo.GetItem(id);
            return View(item);

        }

        [HttpPost]
        public IActionResult Edit(Inward item)
        {
            bool retVal = false;

            try
            {
                retVal = _repo.Edit(item);


            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            Inward item = _repo.GetItem(Id);
            return View(item);

        }

        [HttpPost]
        public IActionResult Delete(Inward item)
        {
            bool boolval = false;

            try
            {

                boolval = _repo.Delete(item);

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetProduct()
        {

            var lsProduct = new List<SelectListItem>();

            PaginatedList<Product> units = _productrepo.GetItems("Name", SortOrder.Ascending);
            lsProduct = units.Select(ut => new SelectListItem()
            {
                Value = ut.Code.ToString(),
                Text = ut.Name


            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Unit----"


            };
            return lsProduct;
        }

        private List<SelectListItem> GetSupplier()
        {

            var lssupplier = new List<SelectListItem>();

            PaginatedList<Supplier> units = _supplierrepo.GetItems("Name", SortOrder.Ascending);
            lssupplier = units.Select(ut => new SelectListItem()
            {
                Value = ut.Id.ToString(),
                Text = ut.FullName


            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Supplier----"


            };
            return lssupplier;
        }
    }
}