using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.ProductProperty
{
    [Table("product_height")]
    public class ProductHeight 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductHeightId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public PropertyStatus Status { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
    }
}
