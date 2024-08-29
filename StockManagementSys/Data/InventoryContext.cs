using Microsoft.EntityFrameworkCore;
using StockManagementSys.Models;

namespace StockManagementSys.Data
{
    public class InventoryContext:DbContext
    {

        public InventoryContext(DbContextOptions options):base(options) 
        { 
        
        
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Brand> Brands { get; set; }


    }
}
