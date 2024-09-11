using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concreate
{
    
        public class Outward
        {
            [Key]
            public int OutwardId { get; set; }

            // Mal çıkışının yapıldığı ControlCheck kaydı
            [Required]
            [ForeignKey("ControlCheck")]
            public int ControlCheckId { get; set; }
            public virtual ControlCheck ControlCheck { get; set; }

            // Mal çıkış miktarı
            [Required]
            public int Quantity { get; set; }

            // Çıkış tarihi
            public DateTime OutwardDate { get; set; }
        }

    }

