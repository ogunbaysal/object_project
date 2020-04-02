using System;
using System.Collections.Generic;
using System.Text;

namespace client.Model
{
    public class SubCategory
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public long ParentCategoryId { get; set; }
        public List<ChildCategory> ChildCategories { get; set; } = null;


    }
}
