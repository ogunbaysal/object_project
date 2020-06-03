using mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobile.Services.Interface
{
    public interface IAppNavigation
    {
        Task LoggedIn(bool result);

        Task ShowRegister();
        Task ShowLogin();
        Task ShowProfile();
        Task ShowHome();
        Task ShowExplore();
        Task ShowBasket();

        Task ShowProduct(Product product);

        Task ShowProductList(List<Product> items, string title, bool canShowSinglePage = false);
    }
}
