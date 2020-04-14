using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using server.Models.Product;
using System.Threading.Tasks;

namespace server.Models.ProductProperty
{
    [Table("product_size")]
    public class ProductSize 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductSizeId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public PropertyStatus Status { get; set; } = PropertyStatus.ACTIVE;
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }

    }
}
