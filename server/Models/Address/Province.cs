using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models.Address
{
    /// <summary>
    /// Şehir 
    /// </summary>
    [Table("province")]
    public class Province
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProvinceId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
