using server.Models.CrossTable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Index = Microsoft.EntityFrameworkCore.Metadata.Internal.Index;

namespace server.Models.ProductProperty
{
    [Table("product_colors")]
    public class ProductColor 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long ProductColorId { get; set; }
        [Required(ErrorMessage = "Tag is required")]
        public string Tag { get; set; }
        [Required(ErrorMessage = "Url is required")]
        public string Url { get; set; }
        public virtual ICollection<ProductProductColor> Products { get;set; }
        public PropertyStatus Status { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
    }
}
