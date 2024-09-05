using CodeByStudent.Tools;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;

namespace StockManagementSys.Repositories
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


            if (SortProperty.ToLower() == "totalquantity")
            {
                if (sortOrder == SortOrder.Ascending)
                {

                    items = items.OrderBy(x => x.TotalQuantity).ToList();
                }
                else
                {
                    items = items.OrderByDescending(x => x.TotalQuantity).ToList();
                }


            }

            else if(SortProperty.ToLower() == "quantity") { if (sortOrder == SortOrder.Ascending)
                        {
                            items = items.OrderBy(d => d.PoDetail.Quantity).ToList();

                        }
                        else
                        {
                            items = items.OrderByDescending(d => d.PoDetail.Quantity).ToList();
                        }
                    }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    items = items.OrderBy(d => d.InwardDetail.Quantity).ToList();

                }
                else
                {
                    items = items.OrderByDescending(d => d.InwardDetail.Quantity).ToList();
                }
            }
            return items;

        }

        public PaginatedList<ControlCheck> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<ControlCheck> check = _context.ControlChecks.ToList();
            
                check = _context.ControlChecks.ToList();

            
            check = DoSort(check, SortProperty, sortOrder);
            PaginatedList<ControlCheck> recheck = new PaginatedList<ControlCheck>(check, pageIndex, pageSize);
            return recheck;
        }

        public ControlCheck GetItem(int id)
        {
            ControlCheck check = _context.ControlChecks.Where(x => x.id == id).FirstOrDefault();
            return check;
        }

    }
}
