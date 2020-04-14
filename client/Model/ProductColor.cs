using System;
using System.Collections.Generic;
using System.Text;
using server.Models.ProductProperty;

namespace client.Model
{
    public class ProductColor
    {
        public long ProductColorId { get; set; }
        public string Tag { get; set; }
        public string Url { get; set; }
        public PropertyStatus Status { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
    }
}
