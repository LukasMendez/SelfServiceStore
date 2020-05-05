using SelfServiceApp.Models;
using SelfServiceApp.Services;
using SelfServiceApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        // Activity monitoring (quick and dirty)
        private const int timeoutSeconds = 10;
        public bool ShouldSignout = true;
        public bool PageActive { get; set; } = false;


        public OrderViewModel() {

           

            Products = new ObservableCollection<Product>();

            // This part monitors inactivity
            CheckActivityState();

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
                (object message) => {
                    PageActive = false;
                    App.Current.MainPage = new MainView();
                    Console.WriteLine("*Cancel*"); },
                (object message) => { Console.WriteLine("*CanCancel*"); return true; });

            //Test Products
            Products.Add(new Product("45678914", "mælk", "økologisk", 1, 8.95));
            Products.Add(new Product("48145414", "rugbrød", "solsikke kerner", 1, 15.95));
            Products.Add(new Product("87654514", "franskbrød", "fuldkorn", 1, 12.95));
        }

        public void CheckActivityState()
        {
            // Copy of current collection
            ObservableCollection<Product> productsCopy = new ObservableCollection<Product>(Products);

            Device.StartTimer(TimeSpan.FromSeconds(timeoutSeconds), () =>
            {

              //   bool equal = productsCopy.SequenceEqual(Products); <-- Another approach 
                ShouldSignout = productsCopy.All(Products.Contains) && productsCopy.Count == Products.Count;

                
                // If both collections contain the same data and have the same count after x amount of time, it means that the user has been inative
                if (ShouldSignout && PageActive)
                {
                    UserLoginService.SignOut();
                    return false; // False = Stop the timer <- Needs to be started again next time page is loaded 
                }
                else
                {
                    // Else we will take a new copy of the current collection and wait x amount of time again
                    productsCopy = new ObservableCollection<Product>(Products);
                    return true;
                }

                
            });
        }
    }
}
