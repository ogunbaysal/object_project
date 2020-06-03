using mobile.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobile.Services
{
    public class NavigationService : INavigationService
    {
        public INavigation Navi { get; internal set; }
        public Page myPage { get; set; }

        public IReadOnlyList<Page> ModalStack => ModalStack;

        public IReadOnlyList<Page> NavigationStack => NavigationStack;

        public Task<bool> DisplayAlert(string title, string message, string accept = "ok", string cancel = "cancel")
        {
            return myPage.DisplayAlert(title, message, accept, cancel);
        }
        public async Task GoToHomeTab()
        {
            await Shell.Current.GoToAsync("//home");
        }
        public async Task GoToProfileTab()
        {
            await Shell.Current.GoToAsync("//profile");
        }
        public async Task GoToDiscoverTab()
        {
            await Shell.Current.GoToAsync("//discover");
        }
        public async Task GoToBasketTab()
        {
            await Shell.Current.GoToAsync("//basket");
        }
        public void InsertPageBefore(Page page, Page before)
        {
            Navi.InsertPageBefore(page, before);
        }

        public Task<Page> PopAsync()
        {
            return Navi.PopAsync();
        }

        public Task<Page> PopAsync(bool animated)
        {
            return Navi.PopAsync(animated);
        }

        public Task<Page> PopModalAsync()
        {
            return Navi.PopModalAsync();
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            return Navi.PopModalAsync(animated);
        }

        public Task PopToRootAsync()
        {
            return Navi.PopToRootAsync();
        }

        public Task PopToRootAsync(bool animated)
        {
            return Navi.PopToRootAsync(animated);
        }

        public Task PushAsync(Page page)
        {
            return Navi.PushAsync(page);
        }

        public Task PushAsync(Page page, bool animated)
        {
            return Navi.PushAsync(page, animated);
        }

        public Task PushModalAsync(Page page)
        {
            return Navi.PushModalAsync(page);
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            return Navi.PushModalAsync(page, animated);
        }

        public void RemovePage(Page page)
        {
            Navi.RemovePage(page);
        }
    }
}
