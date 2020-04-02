using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace client.Helpers
{
    class JObjectToObject
    {
        public static List<T> ConvertList<T>(object list)
        {
            var tmp = new List<T>();
            var arr = ((JArray)list).Children();
            foreach(var one in arr)
            {
                var item = one.ToObject<T>();
                tmp.Add(item);
            }
            return tmp;
        }
    }
}
