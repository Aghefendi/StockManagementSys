using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concreate
{
    public class ControlCheck
    {
        [Key]
        public int id { get; set; }

        [Required]
        [ForeignKey("InwardDetail")]

        public int? InwardDetalId { get; set; }
        public virtual InwardDetail InwardDetail { get;  set; }

        public int WareHouseStockQuantity { get; set; }



        public int TotalStock { 
            get { return (InwardDetail != null ? (int)InwardDetail.Quantity : 0) + WareHouseStockQuantity; } 
        }

        public bool IsStockNegative()
        {
            return TotalStock < 0;
        }
        public void CheckStock()
        {
            if (IsStockNegative())
            {
                throw new InvalidOperationException("Total stock cannot be negative!");
            }
        }
        public void DecreaseStock(int quantity)
        {
            if (quantity > WareHouseStockQuantity)
            {
                throw new InvalidOperationException("Depoda yeterli stok yok!");
            }
            WareHouseStockQuantity -= quantity;
        }


    }
}
