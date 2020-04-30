using SelfServiceApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SelfServiceApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new OrderView();
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
