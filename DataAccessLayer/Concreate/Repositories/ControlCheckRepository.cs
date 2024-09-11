using DataAccessLayer.Abstract;
using Entity.Concreate;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;


namespace DataAccessLayer.Concreate.Repositories
{
    public class ControlCheckRepository : IControlCheck
    {



        private readonly InventoryContext _context;
        public ControlCheckRepository(InventoryContext context)
        {
            _context = context;
        }

        public List<ControlCheck> GetAll()
        {


            // Debugging: Check if data is retrieved


            return _context.ControlChecks
                
                .Include(w => w.InwardDetail)
                .Include(a => a.InwardDetail.Inward)
              
                .Include(c => c.InwardDetail.Product)
                .ToList();
        }

        //private List<ControlCheck> DoSort(List<ControlCheck> items, string SortProperty, SortOrder sortOrder)
        //{


        //    if (SortProperty.ToLower() == "name")
        //    {
        //        if (sortOrder == SortOrder.Ascending)
        //        {

        //            items = items.OrderBy(x => x.InwardDetail.Product.Name).ToList();
        //        }
        //        else
        //        {
        //            items = items.OrderByDescending(x => x.InwardDetail.Product.Name).ToList();
        //        }


        //    }
        //    else
        //    {
        //        if (sortOrder == SortOrder.Ascending)
        //        {
        //            items = items.OrderBy(d => d.PoDetail.Quantity).ToList();

        //        }
        //        else
        //        {
        //            items = items.OrderByDescending(d => d.PoDetail.Quantity).ToList();
        //        }
        //    }
        //    return items;

        //}

        //public PaginatedList<ControlCheck> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        //{
        //    List<ControlCheck> items = _context.ControlChecks

        //        .Include(k => k.PoDetail)
        //        .Include(w => w.InwardDetail)
        //        .Include(a => a.InwardDetail.Inward)
        //        .Include(b => b.PoDetail.PoHeader)
        //        .Include(c => c.InwardDetail.Product)
        //        .ToList();
        //    if (SearchText != "" && SearchText != null)
        //    {
        //        items = _context.ControlChecks.Where(n => n.InwardDetail.Product.Name.Contains(SearchText) || n.PoDetail.Product.Name.Contains(SearchText)).ToList();

        //    }
        //    else
        //    {
        //        items = _context.ControlChecks.ToList();

        //    }
        //    items = DoSort(items, SortProperty, sortOrder);
        //    PaginatedList<ControlCheck> reitems = new PaginatedList<ControlCheck>(items, pageIndex, pageSize);
        //    return reitems;
        //}
    }
}
