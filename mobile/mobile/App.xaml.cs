using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using mobile.Services;
using mobile.Views;
using mobile.Layout;
using mobile.Plugins.Interface;
using mobile.Plugins;
using Autofac;
using mobile.Services.Interface;
using System.Diagnostics;
using mobile.ViewModels.Auth;
using mobile.ViewModels;
using mobile.DataServices;
using mobile.DataServices.Interface;
using mobile.ViewModels.Component;
using mobile.ViewModels.Product;

namespace mobile
{
    public partial class App : Application
    {
        private static IContainer _container;
    
        private static NavigationService NaviService;
        public IContainer CreateContainer()
        {
            ContainerBuilder cb = new ContainerBuilder();

            RegisterDepenencies(cb);

            return cb.Build();
        }
        public App()
        {
            InitializeComponent();
            _container = CreateContainer();

            NaviService = Resolve<INavigationService>() as NavigationService;
            var PageFactory = Resolve<IPageFactory>();
            MainPage = new AppShell();
            NaviService.Navi = MainPage.Navigation;
            NaviService.myPage = MainPage;
        }
        protected void RegisterDepenencies(ContainerBuilder cb)
        {
            cb.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            cb.RegisterType<AppNavigation>().As<IAppNavigation>().SingleInstance();
            cb.RegisterType<PageFactory>().As<IPageFactory>().SingleInstance();
            cb.RegisterType<BasketService>().As<IBasketService>().SingleInstance();


            cb.RegisterType<Storage>().As<IStorage>().SingleInstance();

            //model instances
            cb.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            cb.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            cb.RegisterType<ProductService>().As<IProductService>().SingleInstance();

            //view models

            cb.RegisterType<LoginViewModel>().SingleInstance();
            cb.RegisterType<RegisterViewModel>().SingleInstance();
            cb.RegisterType<ProfileViewModel>().SingleInstance();
            cb.RegisterType<ProductListViewModel>().SingleInstance();
            cb.RegisterType<FlyoutHeaderViewModel>().SingleInstance();
            cb.RegisterType<HomeViewModel>().SingleInstance();
            cb.RegisterType<DiscoveryViewModel>().SingleInstance();
            cb.RegisterType<BasketViewModel>().SingleInstance();

        }
        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        public static T Resolve<T>()
        {
            try
            {
                return _container.Resolve<T>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error resolving type {0}:  {1}", typeof(T).FullName, ex);
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw;
            }
        }

        #region viewModels
        public static LoginViewModel LoginViewModel { get { return Resolve<LoginViewModel>(); } }
        public static RegisterViewModel RegisterViewModel { get { return Resolve<RegisterViewModel>(); } }
        public static ProfileViewModel ProfileViewModel { get { return Resolve<ProfileViewModel>(); } }
        public static ProductListViewModel ProductListViewModel { get { return Resolve<ProductListViewModel>(); } }
        public static FlyoutHeaderViewModel FlyoutHeaderViewModel { get { return Resolve<FlyoutHeaderViewModel>(); } }
        public static HomeViewModel HomeViewModel { get { return Resolve<HomeViewModel>(); } }
        public static DiscoveryViewModel DiscoveryViewModel { get { return Resolve<DiscoveryViewModel>(); } }
        public static ProductDetailViewModel ProductDetailViewModel { get; set; }
        public static BasketViewModel BasketViewModel { get { return Resolve < BasketViewModel>();} }
        #endregion
    }
}
