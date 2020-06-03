using System;
using System.Collections.Generic;
using System.Text;
using mobile.DataServices.Interface;
using mobile.Models;

namespace mobile.ViewModels.Product
{
    public class ProductListViewModel : BaseViewModel
    {
        private readonly IProductService _productService;
        public List<mobile.Models.Product> ProductList { get; set; }
        public ProductListViewModel(IProductService productService)
        {
            _productService = productService;
            ProductList = _productService.GetProductsByCategoryId(2);
        }
    }
}
