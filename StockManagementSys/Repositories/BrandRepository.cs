using CodeByStudent.Tools;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;

namespace StockManagementSys.Repositories
{
    public class BrandRepository : IBrand
    {

        private readonly InventoryContext _context;
        public BrandRepository(InventoryContext context)
        {
            _context = context;
        }



        public Brand Create(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return brand;
        }

        public Brand Delete(Brand brand)
        {
            _context.Brands.Attach(brand);
            _context.Entry(brand).State = EntityState.Deleted;
            _context.SaveChanges();
            return brand;
        }

        public Brand Edit(Brand brand)
        {
            _context.Brands.Attach(brand);
            _context.Entry(brand).State = EntityState.Modified;
            _context.SaveChanges();
            return brand;
        }

        private List<Brand> DoSort(List<Brand> items, string SortProperty, SortOrder sortOrder)
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

        public PaginatedList<Brand> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Brand> Brands = _context.Brands.ToList();
            if (SearchText != "" && SearchText != null)
            {
                Brands = _context.Brands.Where(n => n.Name.Contains(SearchText) || n.Description.Contains(SearchText)).ToList();

            }
            else
            {
                Brands = _context.Brands.ToList();

            }
            Brands = DoSort(Brands, SortProperty, sortOrder);
            PaginatedList<Brand> reBrand = new PaginatedList<Brand>(Brands, pageIndex, pageSize);
            return reBrand;
        }

        public Brand GetItem(int id)
        {
            Brand Brand = _context.Brands.Where(x => x.Id == id).FirstOrDefault();
            return Brand;
        }

    }
}
