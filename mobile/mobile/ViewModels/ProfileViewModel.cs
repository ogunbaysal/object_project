using mobile.Command;
using mobile.DataServices.Interface;
using mobile.Models.Enums;
using mobile.Plugins.Interface;
using mobile.Services.Interface;
using Plugin.SecureStorage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace mobile.ViewModels
{
    public class ProfileViewModel :BaseViewModel
    {
        private readonly IAuthenticationService _authService;
        private readonly IAppNavigation _navigationService;
        public ProfileViewModel(IAuthenticationService authService, IAppNavigation navigationService)
        {
            _authService = authService;
            _navigationService = navigationService;
        }
        public ICommand LogoutCommand { get { return new SimpleCommand(Logout); } }
        private async void Logout()
        {
            _authService.LogOut();
            await _navigationService.ShowProfile();
        }
    }
}
