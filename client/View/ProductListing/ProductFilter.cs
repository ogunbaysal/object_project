using System;
using System.Collections.Generic;
using System.Text;

namespace client.View.ProductListing
{
    //0 is null!
    public class ProductFilter
    {
        public long ChildCategoryId { get; set; } = 0;
        public long SubCategoryId { get; set; } = 0;
    }
}
