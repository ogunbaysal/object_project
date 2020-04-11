using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Order
{
    [Table("order_detail")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
        [Required(ErrorMessage = "Order is required")]
        public Order Order { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Product.ProductProperty ProductProperty { get; set; }
        public double UnitPrice { get; set; }
        public int Piece { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
    }
}
