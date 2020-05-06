
using SelfServiceApp.Helpers;
using SelfServiceApp.Services;
using SelfServiceApp.ViewModels;
using SelfServiceApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SelfServiceApp
{
    public partial class App : Application
    {


        static IWebConnection webConnection;
        public static IWebConnection WebConnection
        {
            get
            {
                if (webConnection == null)
                {
                    webConnection = new WebConnection();
                    
                }
                return webConnection;
            }
        }


        ISettingsService _settingsService;

        public App()
        {
            ServiceContainer.Register<ScanViewModel>(() => new ScanViewModel());
            ServiceContainer.Register<OrderViewModel>(() => new OrderViewModel());
            ServiceContainer.Register<MainViewModel>(() => new MainViewModel());
            ServiceContainer.Register<LoginViewModel>(() => new LoginViewModel());
            ServiceContainer.Register<RegisterViewModel>(() => new RegisterViewModel());

            InitializeComponent();
            ServiceContainer.Register<ISettingsService>(() => new SettingsService());
            _settingsService = ServiceContainer.Resolve<ISettingsService>();


            //var mainPage = new ScanView();
            //MainPage = new NavigationPage(mainPage);
            OnStart();

            ServiceContainer.Register<OrderViewModel>(() => new OrderViewModel());
            ServiceContainer.Register<OrderCompleteViewModel>(() => new OrderCompleteViewModel());


            var mainPage = new ScanView();
            MainPage = new NavigationPage(mainPage);
        }

        protected override void OnStart()
        {
            if (UserLoginService.AuthorizedWithInfo())
            {
                MainPage = new MainView();
            } else
            {
                MainPage = new LoginView();
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
