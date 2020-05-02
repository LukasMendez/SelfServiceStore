using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.SignalR.Client;
using SelfServiceApp.Models;

namespace SelfServiceApp.Services
{
    class WebConnection : IWebConnection
    {
        private HubConnection hubConnection;

        private HttpClient httpClient;

        public bool IsConnected { get; private set; }
        public bool IsBusy { get; private set; }

        public WebConnection()
        {
            // This one is related to SignalR
            hubConnection = new HubConnectionBuilder()
            .WithUrl($"{Constants.HostName}" + "/navHub")
            .Build();


            hubConnection.On<string>(Constants.ScannedProduct, (product) =>
            {
                App.Current.MainPage.DisplayAlert("Message", product, "OK");
            });


        }

        public async void Connect()
        {
            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public async void ScanItem(string barcode)
        {
            try
            {
                await hubConnection.InvokeAsync(Constants.ScanItem, barcode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }

        }

        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(string name, string email, string password, string phoneNo)
        {
            throw new NotImplementedException();
        }
    }
}
