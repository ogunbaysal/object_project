using mobile.DataServices.Interface;
using mobile.Helpers;
using mobile.Models;
using mobile.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.DataServices
{
    public class ProductService : ApiService,IProductService
    {
        public List<Product> GetAllProducts()
        {
            var res = Get("product/all");
            if (res == null) return null;
            if (res.Data == null) return null;
            var list =  JArrayToList.Convert<Product>(res.Data);
            foreach(var item in list)
            {
                string image = GetProductImage(item.ProductId);
                item.ImageUrl = image;
                double price = getProductPrice(item.ProductId);
                item.Price = price;
            }
            return list;
        }
        public string GetProductImage(long productId)
        {
            var res = Get("product/"+productId+"/image");
            if (res == null) return null;
            if (res.Data == null) return null;
            var str = res.Data.ToString();
            return str;
        }
        public double getProductPrice(long productId)
        {
            var res = Get("product/" + productId + "/price");
            if (res == null) return 0;
            if (res.Data == null) return 0;
            var price = double.Parse(res.Data.ToString());
            return price;
        }
        public List<Product> GetProductsByCategoryId(long id)
        {
            var res = Get("product/category/"+id);
            if (res == null) return null;
            if (res.Data == null) return null;
            return JArrayToList.Convert<Product>(res.Data);
        }
        public List<ProductDetail> GetProductDetails(long productId)
        {
            var res = Get("product/properties/" + productId);
            if (res == null) return null;
            if (res.Data == null) return null;
            return JArrayToList.Convert<ProductDetail>(res.Data);
        }
    }
}
