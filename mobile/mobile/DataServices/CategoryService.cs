using mobile.DataServices.Interface;
using mobile.Helpers;
using mobile.Models;
using mobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobile.DataServices
{
    public class CategoryService : ApiService, ICategoryService
    {
        public List<Category> getCategories()
        {
            var res = Get("category/all");
            if (res == null) return null;
            if (res.Data == null) return null;
            return JArrayToList.Convert<Category>(res.Data);
        }
    }
}
