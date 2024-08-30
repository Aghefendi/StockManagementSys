using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagementSys.Models
{
    public class Product
    {

        [Key]
        [StringLength(6)]
        public string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [Column(TypeName ="smallmoney")]
        public decimal Cost { get; set; }

        [Required]
        [Column(TypeName = "smallmoney")]
        public decimal Price { get; set; }
        [Required]

        [ForeignKey("Units")]
        public int UnitId { get; set; }
        public   Unit Units { get; set; }

    }
}
