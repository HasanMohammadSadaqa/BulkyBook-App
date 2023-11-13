using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BulkyWeb_App.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [NotNull]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
