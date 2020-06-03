using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace mobile.Services.Interface
{
    public enum Pages
    {
        Login,
        Register,
        Home,
        Basket,
        Explore,
        Profile,
        ProductDetail,
        ProductList
    }
    public interface IPageFactory
    {
        Page GetPage(Pages page);
    }
}
