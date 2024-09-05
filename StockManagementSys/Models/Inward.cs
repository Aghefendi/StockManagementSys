using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockManagementSys.Models
{
    public class Inward
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string InwardNumber { get; set; }

        [Required]
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; private set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime InwardDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(500)]
        public string Remarks { get; set; }

        // InwardDetail ile ilişki
        public virtual List<InwardDetail> InwardDetails { get; set; } = new List<InwardDetail>();
    }
}
