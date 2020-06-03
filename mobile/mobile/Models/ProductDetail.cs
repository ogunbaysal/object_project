using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class ProductDetail
    {
        public long ProductPropertyId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long? ProductColorId { get; set; }
        public long? ProductHeightId { get; set; }
        public long? ProductSizeId { get; set; }
        public long ProductThemeId { get; set; }
        public long? ProductTrotterId { get; set; }
        public int StockCount { get; set; } = 0;
        public double Price { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
    }
}
