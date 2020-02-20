using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Product
{
    [Table("product_colors")]
    public class ProductColor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long ProductColorId { get; set; }
        [Required(ErrorMessage = "Tag is required")]
        [Index(IsUnique = true)]
        public string Tag { get; set; }
        [Required(ErrorMessage = "Url is required")]
        public string Url { get; set; }
        public Product Product { get;set; }
        public DateTime Date_Added { get; set; }
        public DateTime DateModified { get; set; }
    }
}
