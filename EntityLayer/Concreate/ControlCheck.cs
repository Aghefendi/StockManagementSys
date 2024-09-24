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

        [Required]
        [ForeignKey("Outward")]

        public int? OutwardId { get; set; }
        public virtual Outward Outward { get; set; }





        public int TotalStock { 
            get { return (InwardDetail != null ? (int)InwardDetail.Quantity : 0) - Outward.Quantity; } 
        }

      


    }
}
