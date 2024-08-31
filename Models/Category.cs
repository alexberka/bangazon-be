using System.ComponentModel.DataAnnotations;

namespace bangazon_be.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
