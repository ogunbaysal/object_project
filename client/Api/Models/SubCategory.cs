using System;
using System.Collections.Generic;
using System.Text;

namespace client.Api.Models
{
    class SubCategory
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public long ParentCategoryId { get; set; }

    }
}
