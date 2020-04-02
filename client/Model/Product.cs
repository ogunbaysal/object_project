using System;
using System.Collections.Generic;
using System.Text;

namespace client.Model
{
    public class Product
    {
        public long ProductId { get; set; }
        public ICollection<object> ProductProperties { get; set; }
        public long ChildCategoryId { get; set; }
        public ChildCategory ChildCategory { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
