using client.Api.Core;
using client.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace client.Api
{
    class ProductAPI : ApiService
    {
        public Result GetOne(long id)
        {
            return GetMethod(string.Format("product/one/{0}", id));
        }
        public Result GetPropertyImages(long id)
        {
            return GetMethod(string.Format("property/image/{0}", id));
        }
        public Result GetProperties(long productId)
        {
            return GetMethod(string.Format("properties/{0}", productId));
        }
    }
}
