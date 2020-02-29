using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Category
{
    [Table("child_categories")]
    public class ChildCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ChildCategoryId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Slug is required")]
        public string Slug { get; set; }
        public long SubCategoryId { get; set; }
        [Required(ErrorMessage = "SubCategory is required")]
        public SubCategory SubCategory { get; set; }
        public CategoryStatus Status { get; set; } = CategoryStatus.ACTIVE;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
    }
}
