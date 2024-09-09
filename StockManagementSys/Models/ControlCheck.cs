using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagementSys.Models
{
    public class ControlCheck
    {
        [Key]
        public int id { get; set; }

        [Required]
        [ForeignKey("InwardDetail")]

        public int? InwardDetalId { get; set; }
        public virtual InwardDetail InwardDetail { get;  set; }

        [Required]
        [ForeignKey("PoDetail")]

        public int? PoDetalId { get; set; }
        public virtual PoDetail PoDetail { get;  set; }

        public int TotalQuantity { get; set; }

     
    }
}
