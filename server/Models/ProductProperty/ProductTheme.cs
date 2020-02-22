using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace server.Models.ProductProperty
{
    /// <summary>
    /// Sezon Indirimi, Yeni Ürünler ...
    /// </summary>
    [Table("product_theme")]
    public class ProductTheme 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductThemeId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Slug is required")]
        public string Slug { get; set; }
        public ICollection<Product.Product> Products { get; set; }
        public PropertyStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateMofied { get; set; }

    }
}
