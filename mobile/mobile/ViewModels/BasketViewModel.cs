using mobile.Models;
using mobile.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.ViewModels
{
    public class BasketViewModel : BaseViewModel
    {
        private readonly IBasketService _basket;
        public BasketViewModel(IBasketService basket)
        {
            _basket = basket;
        }
        public List<Basket> Basket { get { return _basket.GetBasket(); } }


    }
}
