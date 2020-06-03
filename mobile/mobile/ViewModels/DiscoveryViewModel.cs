using mobile.Command;
using mobile.DataServices.Interface;
using mobile.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace mobile.ViewModels
{
    public class DiscoveryViewModel : BaseViewModel
    {
        private IProductService _productService;
        private readonly IAppNavigation _navi;
        public List<Models.Product> ProductList { get; set; }
        public ICommand NavigateToProductCommand
        {
            get
            {
                return new SimpleCommand<Models.Product>((Models.Product item) =>
                {
                    NavigateToProduct(item);
                });
            }
        }

        public DiscoveryViewModel(IProductService productService, IAppNavigation navi)
        {
            _productService = productService;
            _navi = navi;
            getProductList();
        }
        private void getProductList()
        {
            ProductList = _productService.GetAllProducts();
        }
        private async void NavigateToProduct(Models.Product param)
        {
            await _navi.ShowProduct(param);
        }
    }
}
