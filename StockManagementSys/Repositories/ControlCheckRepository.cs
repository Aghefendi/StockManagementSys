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

        public List<ControlCheck> GetAll()
        {
            

            // Debugging: Check if data is retrieved
          

            return _context.ControlChecks
                .Include(k=>k.PoDetail)
                .Include(w=>w.InwardDetail)
                .Include(a=>a.InwardDetail.Inward)
                .Include(b=>b.PoDetail.PoHeader)
                .Include(c=>c.InwardDetail.Product)
                .ToList();
        }
    }
}
