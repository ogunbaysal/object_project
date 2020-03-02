using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using server.Models.User;
namespace server.Models.Order
{
    [Table("basket")]
    public class Basket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BasketId { get; set; }
        public long ProductPropertId { get; set; }
        public Product.ProductProperty ProductProperty { get; set; }

        public long UserId { get; set; }
        public User.User User { get; set; }

        public int Count { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }
        public BasketStatus Status { get; set; } = BasketStatus.ACTIVE;

    }
}
