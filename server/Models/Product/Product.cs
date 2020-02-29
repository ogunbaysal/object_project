﻿using server.Models.Category;
using server.Models.ProductProperty;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Product
{
    [Table("products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long ProductId { get; set; }
        public ICollection<ProductProperty> ProductProperties { get; set; }
        public long ChildCategoryId { get; set; }
        [Required(ErrorMessage = "ChildCategory is required")]
        public ChildCategory ChildCategory { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
        
    }
}
