using System;
using System.Collections.Generic;
using System.Text;

namespace client.Model
{
    public class ChildCategory
    {
        public string Id { get; set; }
        public string ParentCategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
