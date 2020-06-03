using mobile.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public CategoryStatus Status { get; set; } = CategoryStatus.ACTIVE;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
    }
}
