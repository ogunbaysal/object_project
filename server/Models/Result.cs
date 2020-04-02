using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Result
    {
        public string Message { get; set; } = null;
        public object Data { get; set; } = null;
        public int Count { get; set; } = 0;
    }
}
