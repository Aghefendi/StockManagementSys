using CodeByStudent.Tools;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;

namespace StockManagementSys.Repositories
{
    public class ProductProfileRepository : IProductProfile
    {

        private readonly InventoryContext _context;
        public ProductProfileRepository(InventoryContext context)
        {
            _context = context;
        }



        public ProductProfile Create(ProductProfile item)
        {
            _context.ProductProfiles.Add(item);
            _context.SaveChanges();
            return item;
        }

        public ProductProfile Delete(ProductProfile item)
        {
            _context.ProductProfiles.Attach(item);
            _context.Entry(item).State = EntityState.Deleted;
            _context.SaveChanges();
            return item;
        }

        public ProductProfile Edit(ProductProfile item)
        {
            _context.ProductProfiles.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }

        private List<ProductProfile> DoSort(List<ProductProfile> items, string SortProperty, SortOrder sortOrder)
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

        public PaginatedList<ProductProfile> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<ProductProfile> ProductProfiles = _context.ProductProfiles.ToList();
            if (SearchText != "" && SearchText != null)
            {
                ProductProfiles = _context.ProductProfiles.Where(n => n.Name.Contains(SearchText) || n.Description.Contains(SearchText)).ToList();

            }
            else
            {
                ProductProfiles = _context.ProductProfiles.ToList();

            }
            ProductProfiles = DoSort(ProductProfiles, SortProperty, sortOrder);
            PaginatedList<ProductProfile> reProductProfile = new PaginatedList<ProductProfile>(ProductProfiles, pageIndex, pageSize);
            return reProductProfile;
        }

        public ProductProfile GetItem(int id)
        {
            ProductProfile ProductProfile = _context.ProductProfiles.Where(x => x.Id == id).FirstOrDefault();
            return ProductProfile;
        }

    }
}
