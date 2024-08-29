using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Models;

namespace StockManagementSys.Data
{
    public class InventoryContext:IdentityDbContext
    {

        public InventoryContext(DbContextOptions options):base(options) 
        { 
        
        
        }
       
        public DbSet<Unit> Units { get; set; }
        public DbSet<Brand> Brands { get; set; }


    }
}
