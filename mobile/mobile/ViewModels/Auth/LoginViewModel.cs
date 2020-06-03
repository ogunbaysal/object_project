using mobile.Command;
using mobile.DataServices.Interface;
using mobile.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mobile.ViewModels.Auth
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authService;
        private readonly IAppNavigation _navigationService;

        public LoginViewModel(IAuthenticationService authService, IAppNavigation navigationService)
        {
            _authService = authService;
            _navigationService = navigationService;
        }

        public ICommand LoginCommand { get { return new SimpleCommand(Login); } }
        public ICommand GoToRegisterCommand { get { return new SimpleCommand(GoToRegister); } }

        public string Password
        {
            get { return GetValue<string>(); }
            set { SetValue<string>(value); }
        }

        public string Username
        {
            get { return GetValue<string>(); }
            set { SetValue<string>(value); }
        }

        private async void Login()
        {
            var result = await _authService.LoginAsync(Username, Password);

            await _navigationService.LoggedIn(result);

        }
        private async void GoToRegister()
        {
            await _navigationService.ShowRegister();
        }

    }
}
