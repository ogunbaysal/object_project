using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Result
    {
        public string Message { get; set; } = null;
        public object Data { get; set; } = null;
        public int Count { get; set; } = 0;
    }
    public class Result<T>
    {
        public string Message { get; set; } = null;
        public T Data { get; set; }
        public int Count { get; set; } = 0;
    }
}
