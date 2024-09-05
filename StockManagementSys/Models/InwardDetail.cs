using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockManagementSys.Models
{
    public class InwardDetail

    {

        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Inward")]
        public int InwardId { get; set; }
        public virtual Inward   Inward { get; private set; }



        [Required]
        [ForeignKey("Product")]
        [MaxLength(6)]
        public string ProductCode { get; set; }
        public virtual Product Product { get; private set; }

        [Column(TypeName = "smallmoney")]
        [Required]
        public decimal Quantity { get; set; }

        [MaxLength(100)]
        [NotMapped]
        public string Desription { get; set; } = "";

        [MaxLength(25)]
        [NotMapped]
        public string UnitName { get; set; } = "";

        public bool IsDeleted { get; set; } = false;

    }
}
