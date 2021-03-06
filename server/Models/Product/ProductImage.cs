﻿using System;
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
        public long ProductPropertyId { get; set; }
        [Required(ErrorMessage = "Product Property is required")]
        public ProductProperty ProductProperty { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }


    }
}
