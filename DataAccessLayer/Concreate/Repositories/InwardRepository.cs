using CodeByStudent.Tools;
using DataAccessLayer.Abstract;
using Entity.Concreate;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;

namespace DataAccessLayer.Concreate.Repositories
{
    public class InwardRepository:IInward
    {
        private readonly InventoryContext _context;
        public InwardRepository(InventoryContext context)
        {
            _context = context;
        }

        public bool Create(Inward items)
        {
            bool retVal = false;



            try
            {
                _context.Inwards.Add(items);
                _context.SaveChanges();
                retVal = true;

            }
            catch
            {


            }
            return false;


        }

        public bool Delete(Inward items)
        {
            return false;
        }

        public bool Edit(Inward items)
        {
            return false;
        }


        private List<Inward> DoSort(List<Inward> items, string SortProperty, SortOrder sortOrder)
        {


            if (SortProperty.ToLower() == "inwardNo")
            {
                if (sortOrder == SortOrder.Ascending)
                {

                    items = items.OrderBy(x => x.InwardNumber).ToList();
                }
                else
                {
                    items = items.OrderByDescending(x => x.InwardNumber).ToList();
                }


            }
            
            else
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    items = items.OrderBy(d => d.InwardDetails).ToList();

                }
                else
                {
                    items = items.OrderByDescending(d => d.InwardDetails).ToList();
                }


            }
            return items;

        }

        public Inward GetItem(int id)
        {
            Inward items = _context.Inwards.Where(x => x.Id == id).Include(y => y.InwardDetails).FirstOrDefault();
            return items;
        }

        public PaginatedList<Inward> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Inward> items;
            if (SearchText != "" && SearchText != null)
            {
                items = _context.Inwards.Where(n => n.InwardNumber.Contains(SearchText) || n.Remarks.Contains(SearchText))
                        .Include(x => x.Supplier)

                        .ToList();

            }
            else
            {
                items = _context.Inwards.Include(x => x.Supplier).ToList();


            }
            items = DoSort(items, SortProperty, sortOrder);
            PaginatedList<Inward> reProduct = new PaginatedList<Inward>(items, pageIndex, pageSize);
            return reProduct;
        }
    }
}
