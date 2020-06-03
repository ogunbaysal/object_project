using mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobile.DataServices.Interface
{
    public interface ICategoryService
    {
        List<Category> getCategories();

    }
}
