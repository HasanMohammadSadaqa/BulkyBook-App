using System.ComponentModel.DataAnnotations;

namespace BulkyWeb_App.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
