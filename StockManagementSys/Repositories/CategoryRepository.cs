using CodeByStudent.Tools;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;

namespace StockManagementSys.Repositories
{
    public class CategoryRepository:ICategory
    {

        private readonly InventoryContext _context;
        public CategoryRepository(InventoryContext context)
        {
            _context = context;
        }



        public Category Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category Delete(Category category)
        {
            _context.Categories.Attach(category);
            _context.Entry(category).State = EntityState.Deleted;
            _context.SaveChanges();
            return category;
        }

        public Category Edit(Category category)
        {
            _context.Categories.Attach(category);
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return category;
        }

        private List<Category> DoSort(List<Category> items, string SortProperty, SortOrder sortOrder)
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

        public PaginatedList<Category> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Category> categories = _context.Categories.ToList();
            if (SearchText != "" && SearchText != null)
            {
                categories = _context.Categories.Where(n => n.Name.Contains(SearchText) || n.Description.Contains(SearchText)).ToList();

            }
            else
            {
                categories = _context.Categories.ToList();

            }
            categories = DoSort(categories, SortProperty, sortOrder);
            PaginatedList<Category> reCategory = new PaginatedList<Category>(categories, pageIndex, pageSize);
            return reCategory;
        }

        public Category GetItem(int id)
        {
            Category category = _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            return category;
        }

    }
}
