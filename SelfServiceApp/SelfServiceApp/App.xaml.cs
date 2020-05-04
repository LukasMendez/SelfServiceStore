
﻿using SelfServiceApp.Services;
using SelfServiceApp.ViewModels;
using SelfServiceApp.Views;
using System;

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

            InitializeComponent();
            ServiceContainer.Register<ISettingsService>(() => new SettingsService());
            _settingsService = ServiceContainer.Resolve<ISettingsService>();
            ServiceContainer.Register<INavigationService>(() => new NavigationService(_settingsService));


            ServiceContainer.Register<OrderViewModel>(() => new OrderViewModel());

            var mainPage = new ScanView();
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
