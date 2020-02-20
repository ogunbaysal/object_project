using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Product
{
    [Table("product_images")]
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ImageId { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Url is required")]
        public string Url { get; set; }
        [Required(ErrorMessage = "Product is required")]
        public Product Product { get; set; }

    }
}
