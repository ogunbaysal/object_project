using System;
using System.Collections.Generic;
using System.Text;
using client.Api.Core;
using client.Model;

namespace client.Api
{
    public class ProductPropertyAPI : ApiService
    {
        public Result GetColor(long id)
        {
            return GetMethod(string.Format("property/color/{0}", id));
        }
        public Result GetSize(long id)
        {
            return GetMethod(string.Format("property/size/{0}", id));
        }
    }
}
