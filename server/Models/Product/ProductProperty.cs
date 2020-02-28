using server.Models.ProductProperty;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Product
{
    [Table("product_propery")]
    public class ProductProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductPropertId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public ProductColor ProductColor { get; set; }
        public ProductHeight ProductHeight { get; set; }
        public ProductSize ProductSize { get; set; }
        public ProductTheme ProductTheme { get; set; }
        public ProductTrotter ProductTrotter { get; set; }
        [Required(ErrorMessage = "Product Stock Count is required")]
        public int StockCount { get; set; } = 0;
        [Required(ErrorMessage = "Price is required")]
        public float Price { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
    }
}
