using mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.DataServices.Interface
{
    public interface IProductService
    {
        List<Product> GetProductsByCategoryId(long id);
        List<Product> GetAllProducts();

    }
}
