using System.ComponentModel.DataAnnotations;

namespace Entity.Concreate
{
    public class Category
    {
       
        public int Id { get; set; }
        [Required]
        [StringLength(20)]

        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Description { get; set; }


    }
}
