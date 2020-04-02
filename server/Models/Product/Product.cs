using server.Models.Category;
using server.Models.ProductProperty;
using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Product
{
    [Table("products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long ProductId { get; set; }
        public ICollection<ProductProperty> ProductProperties { get; set; }
        [Sieve(CanFilter = true)]
        public long ChildCategoryId { get; set; }
        [Required(ErrorMessage = "ChildCategory is required")]
        public ChildCategory ChildCategory { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [Sieve(CanFilter = true, CanSort = true)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Sieve(CanFilter = true)]
        public string Description { get; set; }
        [Sieve(CanFilter = true, CanSort = true, Name = "created")]
        public ProductStatus Status { get; set; } = ProductStatus.ACTIVE;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        [Sieve(CanFilter = true, CanSort = true, Name = "modified")]
        public DateTime DateModified { get; set; }
        
    }
}
