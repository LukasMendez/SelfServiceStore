
﻿using Newtonsoft.Json;
using SelfServiceApp.Models;
using SelfServiceApp.Services;
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
        public ObservableCollection<Product> CurrentOrder { get; set; }
        public Command ScanCommand { set; get; }
        public Command BuyCommand { set; get; }
        public Command CancelCommand { set; get; }

        public OrderViewModel() {
            CurrentOrder = new ObservableCollection<Product>();

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
                (object message) => { Console.WriteLine("*Cancel*"); },
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
            await webConnection.CreateOrder(order);
        }

    }
}
