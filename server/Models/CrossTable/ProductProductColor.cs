using server.Models.ProductProperty;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.CrossTable
{
    public class ProductProductColor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CrossId { get; set; }

        public long ProductId { get; set; }
        public Product.Product Product { get; set; }

        public long ProductColorId { get; set; }
        public ProductColor ProductColor { get; set; }

        public int StockCount { get; set; }
    }
}
