using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Basket
    {
        public long ProductPropertyId { get; set; }
        public int Count { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
    }
}
