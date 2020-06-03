using mobile.DataServices.Interface;
using mobile.Models;
using mobile.Models.Enums;
using mobile.Plugins.Interface;
using mobile.Services.Interface;
using Plugin.SecureStorage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace mobile.Services
{
    public class BasketService : IBasketService
    {
        private readonly IProductService _productService;
        public List<Basket> Basket { get; set; }
        public BasketService(IProductService productService)
        {
            _productService = productService;
            Basket = new List<Basket>();
        }
        public void AddItemBasket(long propertyId, int count, string title = "", double price = 0)
        {
            var item = Basket.Find(x => x.ProductPropertyId == propertyId);
            if (item != null)
            {
                item.Count += count;
            }
            else
            {
                Basket b = new Basket()
                {
                    ProductPropertyId = propertyId,
                    Count = count,
                    Title = title,
                    Price = price
                };
                Basket.Add(b);
            }
        }

        public void RemoveItemBasket(long propertyId)
        {
            var item = Basket.Find(x => x.ProductPropertyId == propertyId);
            if (item != null)
            {
                Basket.Remove(item);
            }
        }

        public List<Basket> GetBasket()
        {
            return Basket;
        }
    }
}
