using CodeByStudent.Tools;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;

namespace StockManagementSys.Repositories
{
    public class ProductRepository:IProduct
    {
        private readonly InventoryContext _context;
        public ProductRepository(InventoryContext context)
        {
            _context = context;
        }



        public Product Create(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Product Delete(Product item)
        {
           item = pGetItem(item.Code);
            _context.Products.Attach(item);
            _context.Entry(item).State = EntityState.Deleted;
            _context.SaveChanges();
            return item;
        }

        public Product Edit(Product item)
        {
            _context.Products.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }

        private List<Product> DoSort(List<Product> items, string SortProperty, SortOrder sortOrder)
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

        public PaginatedList<Product> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Product> items;
            if (SearchText != "" && SearchText != null)
            {
                items = _context.Products.Where(n => n.Name.Contains(SearchText) || n.Description.Contains(SearchText))
                    .Include(x => x.Units)
                    .ToList();

            }
            else
            {
                items = _context.Products.Include(u=>u.Units).ToList();

            }
            items = DoSort(items, SortProperty, sortOrder);
            PaginatedList<Product> reProduct = new PaginatedList<Product>(items, pageIndex, pageSize);
            return reProduct;
        }

        public Product GetItem(string code)
        {
            Product items = _context.Products.Where(u => u.Code == code)
                   .Include(x => x.Units)
                   .FirstOrDefault();
            return items;
        }

        public Product pGetItem(string code)
        {
            Product items = _context.Products.Where(u => u.Code == code)
                   
                   .FirstOrDefault();
            return items;
        }
    }
}
