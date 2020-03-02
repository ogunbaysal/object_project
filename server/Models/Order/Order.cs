using server.Models.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Order
{
    [Table("order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderId { get; set; }
        public long UserId { get; set; }
        [Required(ErrorMessage = "User is required")]
        public User.User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public District District { get; set; }
        public string Address { get; set; }
        public string TrackCode { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; }

    }
}
