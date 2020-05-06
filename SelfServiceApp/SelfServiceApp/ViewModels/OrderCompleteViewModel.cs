using SelfServiceApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SelfServiceApp.ViewModels
{
    class OrderCompleteViewModel : BaseViewModel
    {
        public Command BackCommand { set; get; }
        public OrderCompleteViewModel() {
            this.BackCommand = new Command(
                (object message) =>
                {
                    var orderViewModel = ServiceContainer.Resolve<OrderViewModel>();
                    orderViewModel.CurrentOrder.Clear();
                    orderViewModel.TotalPrice = 0;
                    App.Current.MainPage = new OrderView();
                },
                (object message) => { Console.WriteLine("*"); return true; });
        }
    }
}
