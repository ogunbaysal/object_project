using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Order
{
    public class BasketModel
    {
        [Required(ErrorMessage = "Product Property Id is required")]
        public long ProductPropertId { get; set; }

        [Required(ErrorMessage = "Count is required")]
        public int Count { get; set; }
    }
}
