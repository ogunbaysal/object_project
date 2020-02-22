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
        public ProductSize()
        {
            this.Products = new HashSet<Product.Product>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductSizeId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public virtual ICollection<Product.Product> Products { get; set; }
        public PropertyStatus Status { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }

    }
}
