using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        [Display(Name="Unit")]
        public int UnitId { get; set; }
        public virtual Unit Units { get; set; }

        
        [ForeignKey("Brands")]
        [Display(Name="Brand")]
        public int? BrandId { get; set; }
        public virtual Brand Brands { get; set; }

        [ForeignKey("Categories")]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public virtual Category Categories { get; set; }

        [ForeignKey("ProductGroups")]
        [Display(Name = "ProductGroup")]
        public int? ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroups { get; set; }

        [ForeignKey("ProductProfiles")]
        [Display(Name = "ProductProfile")]
        public int? ProductProfileId { get; set; }
        public virtual ProductProfile ProductProfiles { get; set; }

        public string PhotoUrl { get; set; } = "noimages.png";
        [Display(Name ="Product Photo")]
        [NotMapped]
        public IFormFile ProductPhoto { get; set; }


    }
}
