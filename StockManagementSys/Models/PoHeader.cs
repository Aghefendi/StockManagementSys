using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagementSys.Models
{
    public class PoHeader
    {
        [Key]

        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string PoNumber { get; set; }
        [Required]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PoDate { get; set; }=DateTime.Now;
        [Required]
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; private set; }
        [Required]
        [MaxLength(15)]
        public string QuotationNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime QuotationDate { get; set; }= DateTime.Now;  

        [Required]
        [MaxLength(500)]
        public string PaymentTerms {  get; set; }

        [Required]
        [MaxLength(500)]
        public string Remarks { get; set; }

        public virtual List<PoDetail> PoDetails { get; set; }=new List<PoDetail>();

    }
}
