using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Address
{
    /// <summary>
    /// Ilçe
    /// </summary>
    [Table("district")]
    public class District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DistrictId { get; set; }
        public string Title { get; set; }
        public long ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
