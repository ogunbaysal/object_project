using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace client.Helpers
{
    public class JObjectToObject
    {
        public static T Convert<T>(object data)
        {
            var item = ((JObject)data).ToObject<T>();
            return item;
        }
    }
}
