using mobile.Services.Interface;
using mobile.Views;
using mobile.Views.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace mobile.Services
{
    public class PageFactory : IPageFactory
    {
        public Page GetPage(Pages page)
        {
            switch (page)
            {
                case Pages.Login: return new LoginPage();
                case Pages.Home: return new HomePage();
                case Pages.Register: return new RegisterPage();
                case Pages.Explore: return new DiscoveryPage();
                case Pages.Basket: return new BasketPage();
                case Pages.Profile: return new ProfilePage();
                default: throw new ArgumentException(string.Format("Unknown page type {0}", page));
            }
        }
    }
}
