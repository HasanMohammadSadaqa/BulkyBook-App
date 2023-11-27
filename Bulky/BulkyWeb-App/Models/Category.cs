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
        [MaxLength(30, ErrorMessage ="Category Name must be less than 30 Characters")]
        [DisplayName("Category Name")]    //this is an annotation to display the field as inside the qutation
        public string Name { get; set; }


        [Range(1,100, ErrorMessage ="Display Order must be between 1-100")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
