using System.ComponentModel.DataAnnotations;

namespace StockManagementSys.Models
{
    public class ProductProfile
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]

        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Description { get; set; }
    }
}
