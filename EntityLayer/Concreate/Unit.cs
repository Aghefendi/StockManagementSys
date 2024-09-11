using System.ComponentModel.DataAnnotations;

namespace Entity.Concreate
{
    public class Unit
    {
        public enum SortOrder{Ascending=0, Descending}
        public int Id { get; set; }
        [Required]
        [StringLength(20)]

        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Description { get; set; }


    }
}
