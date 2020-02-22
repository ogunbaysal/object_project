using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Category
{
    [Table("sub_categories")]
    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SubCategoryId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Slug is required")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "Parent Category is required")]
        public Category ParentCategory { get; set; }

        public CategoryStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateMofied { get; set; }
    }
}
