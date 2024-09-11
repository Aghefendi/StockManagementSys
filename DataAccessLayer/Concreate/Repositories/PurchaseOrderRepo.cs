using CodeByStudent.Tools;
using DataAccessLayer.Abstract;
using Entity.Concreate;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;

namespace DataAccessLayer.Concreate.Repositories
{
    public class PurchaseOrderRepo : IPurchaseOrder
    {
        private readonly InventoryContext _context;
        public PurchaseOrderRepo(InventoryContext context)
        {
            _context = context;
        }

        public bool Create(PoHeader items)
        {
            bool retVal = false;
            


            try
            {
                _context.PoHeaders.Add(items);
                _context.SaveChanges();
                retVal = true;

            }
            catch 
            {
              

            }
            return false;


        }

        public bool Delete(PoHeader items)
        {
            return false;
        }

        public bool Edit(PoHeader items)
        {
            return false;
        }
    

    private List<PoHeader> DoSort(List<PoHeader> items, string SortProperty, SortOrder sortOrder)
    {


        if (SortProperty.ToLower() == "ponumber")
        {
            if (sortOrder == SortOrder.Ascending)
            {

                items = items.OrderBy(x => x.PoNumber).ToList();
            }
            else
            {
                items = items.OrderByDescending(x => x.PoNumber).ToList();
            }


        }
        else if(SortProperty.ToLower()=="quotationno")
        {
            if (sortOrder == SortOrder.Ascending)
            {
                items = items.OrderBy(d => d.QuotationNo).ToList();

            }
            else
            {
                items = items.OrderByDescending(d => d.QuotationNo).ToList();
            }
        }
        else
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    items = items.OrderBy(d => d.QuotationDate).ToList();

                }
                else
                {
                    items = items.OrderByDescending(d => d.QuotationDate).ToList();
                }


            }
        return items;

    }

    public PoHeader GetItem(int id)
        {
        PoHeader items =_context.PoHeaders.Where(x=>x.Id == id).Include(y=>y.PoDetails).FirstOrDefault();
            return items;
    }

        public PaginatedList<PoHeader> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
        List<PoHeader> items;
        if (SearchText != "" && SearchText != null)
        {
            items = _context.PoHeaders.Where(n => n.PoNumber.Contains(SearchText) || n.QuotationNo.Contains(SearchText))
                    .Include(x=>x.Supplier)
                    
                    .ToList();

        }
        else
        {
                items = _context.PoHeaders.Include(x => x.Supplier).ToList();


            }
            items = DoSort(items, SortProperty, sortOrder);
        PaginatedList<PoHeader> reProduct = new PaginatedList<PoHeader>(items, pageIndex, pageSize);
        return reProduct;
    }
    }
}
