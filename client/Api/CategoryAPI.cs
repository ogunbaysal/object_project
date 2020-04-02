using client.Api.Core;
using client.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace client.Api
{
    public class CategoryAPI : ApiService
    {
        public Result GetSubCategories(long id)
        {
            return GetMethod(string.Format("category/subs/{0}", id));

        }
        public Result GetCategories()
        {
            return GetMethod("category/all");
        }
        public Result GetChildCategories(long id)
        {
            return GetMethod(string.Format("category/childs/{0}", id));
        }
    }
}
