using mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Services.Interface
{
    public interface IBasketService
    {
        void AddItemBasket(long propertyId, int count, string title = "", double price = 0);
        void RemoveItemBasket(long propertyId);
        List<Basket> GetBasket();
    }
}
