using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Helpers
{
    public class JArrayToList
    {
        public static List<T> Convert<T>(object data)
        {
            var list = new List<T>();
            var arr = ((JArray)data).Children();
            foreach (var i in arr)
            {
                var item = i.ToObject<T>();
                list.Add(item);
            }
            return list;
        }
    }
}
