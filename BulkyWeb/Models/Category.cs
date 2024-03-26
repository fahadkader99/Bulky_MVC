using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BulkyWeb.Models
{
    public class Category
    {
        // Data Annotation - usefull for Client side UI or Client side Data Validation also for SQL


        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public String? Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage ="Display Order must be between 1-100")]
        public int DisplayOrder { get; set; } 
        

    }
}
