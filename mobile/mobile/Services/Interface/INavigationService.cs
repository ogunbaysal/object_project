using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobile.Services.Interface
{
    public interface INavigationService : INavigation
    {
        Task<bool> DisplayAlert(string title, string message, string accept = "ok", string cancel = "cancel");
        Task GoToHomeTab();
        Task GoToDiscoverTab();
        Task GoToProfileTab();
        Task GoToBasketTab();
    }
}
