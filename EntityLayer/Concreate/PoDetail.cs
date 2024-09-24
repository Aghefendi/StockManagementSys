
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concreate
{
    public class PoDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("PoHeader")]
        public int PoId { get; set; }
        public virtual PoHeader PoHeader { get; private set; }

       

        [Required]
        [ForeignKey("Product")]
        [MaxLength(6)]
        public string ProductCode { get; set; }
        public virtual Product Product { get; private set; }

      
        public int Quantity { get; set; }

        [MaxLength(100)]
        [NotMapped]
        public string Desription { get; set; } = "";

        [MaxLength(25)]
        [NotMapped]
        public string UnitName { get; set; } = "";

        public bool IsDeleted { get; set; }=false;


    }
}
