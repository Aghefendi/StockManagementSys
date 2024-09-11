using System.ComponentModel.DataAnnotations;

namespace Entity.Concreate
{
    public class Supplier {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(6)]
        public string Code { get; set; }
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string EmailId { get; set; } 
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string PhoneNo { get; set; }



    }
}
