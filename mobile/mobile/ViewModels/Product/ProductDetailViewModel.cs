using mobile.Command;
using mobile.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace mobile.ViewModels.Product
{
    public class ProductDetailViewModel : BaseViewModel
    {
        public Models.Product Product { get; set; }
        private readonly IBasketService _basket;
        public ProductDetailViewModel(Models.Product product)
        {
            Product = product;
            _basket = App.Resolve<IBasketService>();
        }
        public ICommand AddBasket
        {
            get
            {
                return new SimpleCommand(addItemToBasket);
            }
        }
        private void addItemToBasket()
        {
            _basket.AddItemBasket(Product.ProductId, 1, Product.Title, Product.Price);
        }
    }
}
