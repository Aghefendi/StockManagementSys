using CodeByStudent.Tools;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;

namespace StockManagementSys.Repositories
{
    public class SupplierRepository : ISupplier
    {
        private readonly InventoryContext _context;
        public SupplierRepository(InventoryContext context)
        {
            _context = context;
        }
        public Supplier Create(Supplier items)
        {
            _context.Suppliers.Add(items);
            _context.SaveChanges();
            return items;
        }

        public Supplier Delete(Supplier items)
        {
            _context.Suppliers.Attach(items);
            _context.Entry(items).State = EntityState.Deleted;
            _context.SaveChanges();
            return items;
        }

        public Supplier Edit(Supplier items)
        {
            _context.Suppliers.Attach(items);
            _context.Entry(items).State = EntityState.Modified;
            _context.SaveChanges();
            return items;
        }

        public Supplier GetItem(int id)
        {
            Supplier item = _context.Suppliers.Where(x => x.Id == id).FirstOrDefault();
            return item;
        }
        private List<Supplier> DoSort(List<Supplier> items, string SortProperty, SortOrder sortOrder)
        {


            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                {

                    items = items.OrderBy(x => x.FullName).ToList();
                }
                else
                {
                    items = items.OrderByDescending(x => x.FullName).ToList();
                }


            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    items = items.OrderBy(d => d.Code).ToList();

                }
                else
                {
                    items = items.OrderByDescending(d => d.Code).ToList();
                }
            }
            return items;
        }
        public PaginatedList<Supplier> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Supplier> items = _context.Suppliers.ToList();
            if (SearchText != "" && SearchText != null)
            {
                items = _context.Suppliers.Where(n => n.FullName.Contains(SearchText) || n.Code.Contains(SearchText)).ToList();

            }
            else
            {
                items = _context.Suppliers.ToList();

            }
            items = DoSort(items, SortProperty, sortOrder);
            PaginatedList<Supplier> reBrand = new PaginatedList<Supplier>(items, pageIndex, pageSize);
            return reBrand;
        }
    }

       

       
}
