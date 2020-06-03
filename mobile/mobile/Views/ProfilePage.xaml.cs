using mobile.Models.Enums;
using mobile.Plugins;
using mobile.Plugins.Interface;
using mobile.Services.Interface;
using Plugin.SecureStorage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private ISecureStorage _storage;
        private IAppNavigation _navi;
        public bool IsLoggedIn { get; set; }
        public ProfilePage()
        {
            InitializeComponent();
            _storage = App.Resolve<IStorage>().SecureStorage;    
            _navi = App.Resolve<IAppNavigation>();
        }
        private void checkAuth()
        {
            base.OnAppearing();
            if (_storage.HasKey(StorageKeys.ACCESS_TOKEN.Value))
            {
            }
            else
            {
                _navi.ShowLogin();
            }
        }
        protected override void OnAppearing()
        {
            checkAuth();
        }

    }
}