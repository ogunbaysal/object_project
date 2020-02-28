using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Filter
{
    public class PaginationSearchModel
    {
        public string? searchString { get; set; }
        public int? page { get; set; }
        public int? itemCount { get; set; }
        public string? sort { get; set; }
    }
}
