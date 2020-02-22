using server.Models.CrossTable;
using server.Models.ProductProperty;
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
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public float Price { get; set; }

        #region many -> many
        public virtual ICollection<ProductProductSize> ProductSizes { get; set; }
        public virtual ICollection<ProductProductColor> ProductColors { get; set; }
        public virtual ICollection<ProductProductTheme> ProductThemes { get; set; }
        public virtual ICollection<ProductProductHeight> ProductHeights { get; set; } 
        public virtual ICollection<ProductProductTrotter> ProductTrotters { get; set; }
        #endregion

        #region many -> one
        public virtual ICollection<ProductImage> ProductImages { get; set; }

        #endregion
        [Required(ErrorMessage = "Product count is required")]
        public int StockCount { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        
    }
}
