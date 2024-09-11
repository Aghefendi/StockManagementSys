using Entity.Concreate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;





namespace StockManagementSys.Data
{
    public class InventoryContext:IdentityDbContext
    {
        public InventoryContext()
        {
        }

        public InventoryContext(DbContextOptions options):base(options) 
        { 
        
        
        }
       
        public DbSet<Unit> Units { get; set; }
       

        public DbSet<Category> Categories { get; set; }
      

        public DbSet<Product> Products { get; set; }

       public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PoHeader> PoHeaders { get; set; }
        public DbSet<PoDetail> PoDetails { get; set; }
        public DbSet<Inward> Inwards { get; set; }
      public DbSet<ControlCheck> ControlChecks { get; set; }
        public DbSet<Outward> Outwards { get; set; }
      

    }
}
