using System;
using System.Collections.Generic;
using System.Text;

namespace client.Model
{
    public class ProductProperty
    {
        public long ProductPropertyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long? ProductColorId { get; set; }
        public object ProductColor { get; set; }
        public long? ProductHeightId { get; set; }
        public object ProductHeight { get; set; }
        public long? ProductSizeId { get; set; }
        public object ProductSize { get; set; }
        public long ProductThemeId { get; set; }
        public object ProductTheme { get; set; }
        public long? ProductTrotterId { get; set; }
        public object ProductTrotter { get; set; }
        public int StockCount { get; set; } = 0;
        public float Price { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
