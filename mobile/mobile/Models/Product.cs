using mobile.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public long ChildCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.ACTIVE;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
    }
}
