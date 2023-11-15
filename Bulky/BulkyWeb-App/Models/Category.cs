using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BulkyWeb_App.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [NotNull]
        [DisplayName("Category Name")]    //this is an annotation to display the field as inside the qutation
        public string Name { get; set; }

        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
