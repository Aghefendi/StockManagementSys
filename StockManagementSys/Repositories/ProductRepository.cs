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
            List<Product> product = _context.Products.Include(p=>p.Units).ToList();
            if (SearchText != "" && SearchText != null)
            {
                product = _context.Products.Where(n => n.Name.Contains(SearchText) || n.Description.Contains(SearchText)).ToList();

            }
            else
            {
                product = _context.Products.ToList();

            }
            product = DoSort(product, SortProperty, sortOrder);
            PaginatedList<Product> reProduct = new PaginatedList<Product>(product, pageIndex, pageSize);
            return reProduct;
        }

        public Product GetItem(string code)
        {
            Product item = _context.Products.Where(p => p.Code == code).FirstOrDefault();
            return item;
        }
    }
}
