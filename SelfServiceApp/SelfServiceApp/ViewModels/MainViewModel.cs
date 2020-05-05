using System;
using SelfServiceApp.Services;
using SelfServiceApp.Views;
using Xamarin.Forms;

namespace SelfServiceApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {

        }

        public Command NewOrderCommand
        {
            get
            {
                return new Command(() =>

                {
                    // Get a reference to the orderviewmodel
                    var orderViewModel = ServiceContainer.Resolve<OrderViewModel>();
                    // Clear the collection of products from previous
                    orderViewModel.CurrentOrder.Clear();
                    orderViewModel.PageActive = true;
                    orderViewModel.CheckActivityState();
                    // Switch to the orderview so the user can see it
                    App.Current.MainPage = new OrderView();

                });
            }
        }

        public Command SignOutCommand
        {
            get
            {
                return new Command(() =>
                {
                    UserLoginService.SignOut();
                });
            }
        }


    }
}
