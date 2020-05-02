using System;
using SelfServiceApp.Services;
using SelfServiceApp.ViewModels;
using SelfServiceApp.Views;
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

        public App()
        {
            WebConnection.Connect();

            ServiceContainer.Register<ScanViewModel>(() => new ScanViewModel());
            ServiceContainer.Register<OrderViewModel>(() => new OrderViewModel());

            InitializeComponent();

            MainPage = new ScanView();
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
