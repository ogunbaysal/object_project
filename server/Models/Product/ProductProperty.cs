﻿using server.Models.ProductProperty;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Product
{
    [Table("product_property")]
    public class ProductProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductPropertyId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public long? ProductColorId { get; set; }
        public ProductColor ProductColor { get; set; }
        public long? ProductHeightId { get; set; }
        public ProductHeight ProductHeight { get; set; }
        public long? ProductSizeId { get; set; }
        public ProductSize ProductSize { get; set; }
        public long ProductThemeId { get; set; }
        public ProductTheme ProductTheme { get; set; }
        public long? ProductTrotterId { get; set; }
        public ProductTrotter ProductTrotter { get; set; }
        [Required(ErrorMessage = "Product Stock Count is required")]
        public int StockCount { get; set; } = 0;
        [Required(ErrorMessage = "Price is required")]
        public float Price { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
    }
}
