using Newtonsoft.Json;
using SelfServiceApp.Models;
using SelfServiceApp.Services;
using SelfServiceApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SelfServiceApp.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public ObservableCollection<Product> CurrentOrder { get; set; }
        private double totalPrice;

        public double TotalPrice {
            get { return totalPrice; }
            set {
                totalPrice = value;
                this.OnPropertyChanged();
            }
        }

        public Command ScanCommand { set; get; }
        public Command BuyCommand { set; get; }
        public Command CancelCommand { set; get; }

        // Activity monitoring (quick and dirty)
        private const int timeoutSeconds = 45; // Seconds of inactivity before closing session
        public bool ShouldSignout = true;
        public bool PageActive { get; set; } = false;


        public OrderViewModel() {

            CurrentOrder = new ObservableCollection<Product>();

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
                (object message) => 
                { 
                    Console.WriteLine("*Buy*");
                    PurchaseCurrentOrder();
                },
                (object message) => { Console.WriteLine("*CanBuy*"); return true; });
            this.CancelCommand = new Command(
                (object message) => {
                    PageActive = false;
                    App.Current.MainPage = new MainView();
                    Console.WriteLine("*Cancel*"); },
                (object message) => { Console.WriteLine("*CanCancel*"); return true; });

            //Test Products
            CurrentOrder.Add(new Product("574923923", "Beef", "Regular beef", 1, 20.00));
            CurrentOrder.Add(new Product("123456554", "Milk", "Milk", 1, 40.00));
            CurrentOrder.Add(new Product("148382383", "Nutella", "Nutella", 1, 40.00));
        }

        WebConnection webConnection = new WebConnection(); 
        private async void PurchaseCurrentOrder() {
            //Create Order Object
            Order order = new Order(new List<Product>(CurrentOrder), "test@mail.dk");
            HttpResponseMessage response = await webConnection.CreateOrder(order);
            if (response.IsSuccessStatusCode) {
                App.Current.MainPage = new OrderCompleteView();
            }
        }

        public void CheckActivityState()
        {
            // Copy of current collection
            ObservableCollection<Product> productsCopy = new ObservableCollection<Product>(CurrentOrder);

            Device.StartTimer(TimeSpan.FromSeconds(timeoutSeconds), () =>
            {

              //   bool equal = productsCopy.SequenceEqual(Products); <-- Another approach 
                ShouldSignout = productsCopy.All(CurrentOrder.Contains) && productsCopy.Count == CurrentOrder.Count;

                
                // If both collections contain the same data and have the same count after x amount of time, it means that the user has been inative
                if (ShouldSignout && PageActive)
                {
                    UserLoginService.SignOut();
                    return false; // False = Stop the timer <- Needs to be started again next time page is loaded 
                }
                else
                {
                    // Else we will take a new copy of the current collection and wait x amount of time again
                    productsCopy = new ObservableCollection<Product>(CurrentOrder);
                    return true;
                }

                
            });
        }
    }
}
