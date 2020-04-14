using System;
using System.Collections.Generic;
using System.Text;

namespace client.View.ProductDetail
{
    public class ProductPropertyDetail<T>
    {
        public long ProductPropertyId { get; set; }
        public T Data { get; set; }
    }
}
