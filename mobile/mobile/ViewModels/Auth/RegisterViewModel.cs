using mobile.Command;
using mobile.DataServices.Interface;
using mobile.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace mobile.ViewModels.Auth
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IAppNavigation _navigation;
        private readonly IAuthenticationService _auth;
        private readonly INavigationService d;
        public RegisterViewModel(IAppNavigation navigation, IAuthenticationService authService, INavigationService display)
        {
            _navigation = navigation;
            _auth = authService;
            d = display;
        }
        public ICommand GoToLoginCommand { get { return new SimpleCommand(GoToLogin); } }
        public ICommand RegisterCommand { get { return new SimpleCommand(Register); } }
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
        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue<string>(value); }
        }
        public string Firstname
        {
            get { return GetValue<string>(); }
            set { SetValue<string>(value); }
        }
        public string Lastname
        {
            get { return GetValue<string>(); }
            set { SetValue<string>(value); }
        }
        private async void GoToLogin()
        {
            await _navigation.ShowLogin();
        }
        private async void Register()
        {
            var result = await _auth.RegisterAsync(Firstname, Lastname, Email, Username, Password);
            if(result)
            {
                await d.DisplayAlert("Kayıt Ol", "Kayıt İşleminiz başarıyla gerçekleştirildi");
                await _navigation.ShowLogin();
            }
            else
            {
                await d.DisplayAlert("Error", "Kayıt işlemi yapılırken bir hata oluştu. Lütfen formu kontrol edip tekrar deneyiniz!");

            }
        }
    }
}
