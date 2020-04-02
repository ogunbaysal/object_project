using System;
using System.Collections.Generic;
using System.Text;

namespace client.Model
{
    public class ProductImage
    {
        public long ImageId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public long ProductPropertyId { get; set; }
        public ProductProperty ProductProperty { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
    }
}
