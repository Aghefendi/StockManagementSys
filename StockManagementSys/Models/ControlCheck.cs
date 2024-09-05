using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagementSys.Models
{
    public class ControlCheck
    {
        [Key]
        public int id { get; set; }
        [Required]
        [ForeignKey("Inward")]

        public int Inwardid { get; set; }
        public virtual Inward Inward { get; set; }

        [Required]
        [ForeignKey("PoHeader")]

        public int PoHeaderId { get; set; }
        public virtual PoHeader PoHeader { get; set; }

        public int TotalQuantity { get; set; }
    }
}
