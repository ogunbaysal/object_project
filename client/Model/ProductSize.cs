using System;
using System.Collections.Generic;
using System.Text;
using server.Models.ProductProperty;

namespace client.Model
{
    public class ProductSize
    {
        public long ProductSizeId { get; set; }
        public string Title { get; set; }
        public PropertyStatus Status { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
    }
}
