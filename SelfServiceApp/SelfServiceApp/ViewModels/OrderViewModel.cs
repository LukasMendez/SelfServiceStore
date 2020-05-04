using SelfServiceApp.Models;
using SelfServiceApp.Views;
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
        public ObservableCollection<Product> Products { get; set; }
        public Command ScanCommand { set; get; }
        public Command BuyCommand { set; get; }
        public Command CancelCommand { set; get; }

        public OrderViewModel() {
            Products = new ObservableCollection<Product>();

            this.ScanCommand = new Command(
                (object message) =>
                {
                    var scanViewModel = ServiceContainer.Resolve<ScanViewModel>();
                    scanViewModel.StartScanning();
                    App.Current.MainPage = new ScanView();

                    Console.WriteLine("*Scan*");
                },
                (object message) => { Console.WriteLine("*CanScan*"); return true; });
            this.BuyCommand = new Command(
                (object message) => { Console.WriteLine("*Buy*"); },
                (object message) => { Console.WriteLine("*CanBuy*"); return true; });
            this.CancelCommand = new Command(
                (object message) => { Console.WriteLine("*Cancel*"); },
                (object message) => { Console.WriteLine("*CanCancel*"); return true; });

            //Test Products
            Products.Add(new Product("45678914", "mælk", "økologisk", 1, 8.95));
            Products.Add(new Product("48145414", "rugbrød", "solsikke kerner", 1, 15.95));
            Products.Add(new Product("87654514", "franskbrød", "fuldkorn", 1, 12.95));
        }
    }
}
