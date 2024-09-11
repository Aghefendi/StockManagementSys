using CodeByStudent.Tools;
using DataAccessLayer.Abstract;
using Entity.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SortOrder = CodeByStudent.Tools.SortOrder;





namespace StockManagementSys.Controllers
{
    [Authorize]
    public class ProductController : Controller

    {
        private readonly IWebHostEnvironment _webHost;
      
        private readonly ICategory _categoryRepo;
       
   

        private readonly IUnits _unitRepo;
        private readonly IProduct _productRepo;
        public ProductController(IProduct productrepo, IUnits unitRepo,ICategory categoryRepo,IWebHostEnvironment webHost)
        {


            _productRepo = productrepo;
            _unitRepo = unitRepo;
         
            _categoryRepo = categoryRepo;
         
            _webHost = webHost;
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
           

            PaginatedList<Product> products = _productRepo.GetItems(sortModel.SortProperty, sortModel.SortOrder, SearchText, pg, pageSize);
            var pager = new PagerModel(products.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;
            TempData["CurrentPage"] = pg;
            return View(products);
        }


        public IActionResult Create()
        {
            Product product = new Product();
            ViewBag.Units = GetUnits();
            
            ViewBag.Categories= GetCategories();
            


            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {


            try
            {
                string uniqueFileName = GetUploadedFileName(product);
                product.PhotoUrl = uniqueFileName;
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
            ViewBag.Units=GetUnits();
           
            ViewBag.Categories = GetCategories();
            
            TempData.Keep();
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

            PaginatedList<Unit> units = _unitRepo.GetItems("Name", SortOrder.Ascending);
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

       

        private List<SelectListItem> GetCategories()
        {

            var IsItem = new List<SelectListItem>();

            PaginatedList<Category> items = _categoryRepo.GetItems("Name", SortOrder.Ascending);
            IsItem = items.Select(ut => new SelectListItem()
            {
                Value = ut.Id.ToString(),
                Text = ut.Name


            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Category----"


            };

            IsItem.Insert(0, defItem);


            return IsItem;
        }

        

        

        private string GetUploadedFileName(Product product) {
            string uniqueFileName = null;
            if(product.ProductPhoto != null)
            {
                string uploadsFile = Path.Combine(_webHost.WebRootPath, "images");
                uniqueFileName=Guid.NewGuid().ToString()+"_"+product.ProductPhoto.FileName;
                string filePath = Path.Combine(uploadsFile, uniqueFileName);
                using(var fileStream=new FileStream(filePath, FileMode.Create))
                {

                    product.ProductPhoto.CopyTo(fileStream);
                }



            }
            return uniqueFileName;
        
        
        
        }
       


    }
}
