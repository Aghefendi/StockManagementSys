using CodeByStudent.Tools;
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

     
        private List<ControlCheck> DoSort(List<ControlCheck> items, string SortProperty, SortOrder sortOrder)
        {


            if (SortProperty.ToLower() == "inwardNo")
            {
                if (sortOrder == SortOrder.Ascending)
                {

                    items = items.OrderBy(x => x.InwardDetalId).ToList();
                }
                else
                {
                    items = items.OrderByDescending(x => x.InwardDetalId).ToList();
                }


            }

            else
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    items = items.OrderBy(d => d.Outward.OutwardDate).ToList();

                }
                else
                {
                    items = items.OrderByDescending(d => d.id).ToList();
                }


            }
            return items;

        }

        public PaginatedList<ControlCheck> GetAll(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<ControlCheck> items = _context.ControlChecks

                
                .Include(w => w.InwardDetail)
                .Include(a => a.InwardDetail.Inward)
                .Include(c=>c.InwardDetail.Product)
                .Include(z=>z.Outward)
               
                .ToList();
            if (SearchText != "" && SearchText != null)
            {
                items = _context.ControlChecks.Where(n => n.InwardDetail.Product.Name.Contains(SearchText) || n.InwardDetail.Product.Name.Contains(SearchText)).ToList();

            }
            else
            {
                items = _context.ControlChecks.ToList();

            }
            items = DoSort(items, SortProperty, sortOrder);
            PaginatedList<ControlCheck> reitems = new PaginatedList<ControlCheck>(items, pageIndex, pageSize);
            return reitems;
        }
    }
}
