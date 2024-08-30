using CodeByStudent.Tools;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;

namespace StockManagementSys.Repositories
{
    public class ProductGroupRepository : IProductGroup
    {

        private readonly InventoryContext _context;
        public ProductGroupRepository(InventoryContext context)
        {
            _context = context;
        }



        public ProductGroup Create(ProductGroup item)
        {
            _context.ProductGroups.Add(item);
            _context.SaveChanges();
            return item;
        }

        public ProductGroup Delete(ProductGroup item)
        {
            
            _context.ProductGroups.Attach(item);
            _context.Entry(item).State = EntityState.Deleted;
            _context.SaveChanges();
            return item;
        }

        public ProductGroup Edit(ProductGroup item)
        {
            _context.ProductGroups.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }

        private List<ProductGroup> DoSort(List<ProductGroup> items, string SortProperty, SortOrder sortOrder)
        {


            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                {

                    items = items.OrderBy(x => x.Name).ToList();
                }
                else
                {
                    items = items.OrderByDescending(x => x.Name).ToList();
                }


            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    items = items.OrderBy(d => d.Description).ToList();

                }
                else
                {
                    items = items.OrderByDescending(d => d.Description).ToList();
                }
            }
            return items;

        }

        public  PaginatedList<ProductGroup> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<ProductGroup> productgroup = _context.ProductGroups.ToList();
            if (SearchText != "" && SearchText != null)
            {
                productgroup = _context.ProductGroups.Where(n => n.Name.Contains(SearchText) || n.Description.Contains(SearchText)).ToList();

            }
            else
            {
                productgroup = _context.ProductGroups.ToList();

            }
            productgroup = DoSort(productgroup, SortProperty, sortOrder);
            PaginatedList<ProductGroup> reProductgroup = new PaginatedList<ProductGroup>(productgroup, pageIndex, pageSize);
            return reProductgroup;
        }

        public ProductGroup GetItem(int id)
        {
            ProductGroup item = _context.ProductGroups.Where(x => x.Id == id).FirstOrDefault();
            return item;
        }

    }
}
