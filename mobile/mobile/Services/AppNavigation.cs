using mobile.DataServices.Interface;
using mobile.Models;
using mobile.Services.Interface;
using mobile.ViewModels.Product;
using mobile.Views.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobile.Services
{
    public class AppNavigation : IAppNavigation
    {
        private readonly IAuthenticationService _login;
        private readonly INavigationService _navi;
        private readonly IPageFactory _pages;

        public AppNavigation(INavigationService navi, IPageFactory pages, IAuthenticationService login)
        {
            _navi = navi;
            _pages = pages;
            _login = login;
        }

        public async Task LoggedIn(bool result)
        {
            if (result)
            {
                await _navi.DisplayAlert("Kullanıcı Girişi", "Başarıyla giriş yaptınız", "tamam");
                await _navi.PopToRootAsync(true);
            }
            else
            {
                await _navi.DisplayAlert("Error", "Lütfen kullanıcı adınızı ve şifrenizi kontrol ediniz!", "ok");
            }
        }

        public async Task ShowBasket()
        {
            await _navi.GoToBasketTab();
        }

        public async Task ShowExplore()
        {
            await _navi.GoToDiscoverTab();
        }

        public async Task ShowHome()
        {
            await _navi.GoToHomeTab();
        }

        public async Task ShowLogin()
        {
            var isLoggedIn =  _login.IsLoggedIn();
            if (isLoggedIn)
            {
                await _navi.GoToProfileTab();
            }
            else
            {
                await _navi.PopToRootAsync(false);
                await _navi.PushAsync(_pages.GetPage(Pages.Login), false);
            }
        }
        public async Task ShowRegister()
        {
            var isLoggedIn = _login.IsLoggedIn();
            if (isLoggedIn)
            {
                await _navi.GoToProfileTab();
            }
            else
            {
                await _navi.PopToRootAsync(false);
                await _navi.PushAsync(_pages.GetPage(Pages.Register), false);
            }
        }
        public async Task ShowProfile()
        {

            var isLoggedIn = _login.IsLoggedIn();
            if(isLoggedIn)
            {
                await _navi.GoToProfileTab();
            }
            else
            {
                await _navi.PushAsync(_pages.GetPage(Pages.Profile));
            }
        }
        public async Task ShowProduct(Product product)
        {
            var productViewModel = new ProductDetailViewModel(product);
            App.ProductDetailViewModel = productViewModel;
            await _navi.PushAsync(new ProductDetailPage());
        }

        public async Task ShowProductList(List<Product> items, string title, bool canShowSinglePage = false)
        {
            await _navi.PushAsync(_pages.GetPage(Pages.ProductList));
        }
    }
}
