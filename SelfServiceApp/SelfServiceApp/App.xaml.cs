using SelfServiceApp.Services;
using SelfServiceApp.ViewModels;
using SelfServiceApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SelfServiceApp
{
    public partial class App : Application
    {
        ISettingsService _settingsService;
        public App()
        {
            InitializeComponent();
            ServiceContainer.Register<ISettingsService>(() => new SettingsService());
            _settingsService = ServiceContainer.Resolve<ISettingsService>();
            ServiceContainer.Register<INavigationService>(() => new NavigationService(_settingsService));

            ServiceContainer.Register<OrderViewModel>(() => new OrderViewModel());

            var mainPage = new OrderView();
            MainPage = new NavigationPage(mainPage);
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
    }
}
