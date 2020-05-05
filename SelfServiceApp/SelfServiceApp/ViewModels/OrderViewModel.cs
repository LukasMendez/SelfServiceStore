using Newtonsoft.Json;
using SelfServiceApp.Models;
using SelfServiceApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SelfServiceApp.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public ObservableCollection<Product> CurrentOrder { get; set; }
        public Command ScanCommand { set; get; }
        public Command BuyCommand { set; get; }
        public Command CancelCommand { set; get; }

        public OrderViewModel() {
            CurrentOrder = new ObservableCollection<Product>();

            this.ScanCommand = new Command(
                (object message) => { Console.WriteLine("*Scan*");},
                (object message) => { Console.WriteLine("*CanScan*"); return true; });
            this.BuyCommand = new Command(
                (object message) => { Console.WriteLine("*Buy*"); },
                (object message) => { Console.WriteLine("*CanBuy*"); return true; });
            this.CancelCommand = new Command(
                (object message) => { Console.WriteLine("*Cancel*"); },
                (object message) => { Console.WriteLine("*CanCancel*"); return true; });

            //Test Products
            CurrentOrder.Add(new Product(10001, "45678914", "mælk", "økologisk", 1, 8.95));
            CurrentOrder.Add(new Product(10002, "48145414", "rugbrød", "solsikke kerner", 1, 15.95));
            CurrentOrder.Add(new Product(10003, "87654514", "franskbrød", "fuldkorn", 1, 12.95));
        }

        WebConnection webConnection = new WebConnection(); 
        private async void PurchaseCurrentOrder() {
            //Create Order Object
            Order order = new Order(new List<Product>(CurrentOrder), "test@mail.dk");
            await webConnection.CreateOrder(order);
        }

    }
}
