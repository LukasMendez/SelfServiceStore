using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SelfServiceApp.Helpers;
using SelfServiceApp.Models;
using Xamarin.Essentials;

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

            httpClient = new HttpClient();

            hubConnection.On<string>(Constants.ScannedProduct, (product) =>
            {
                App.Current.MainPage.DisplayAlert("Message", product, "OK");
            });


        }


        public async Task<Product> ScanItem(string barcode)
        {
            var post = new { Barcode = barcode };

            // Product to be returned
            Product product = null;

            var content = JsonConvert.SerializeObject(post);
            Console.WriteLine(content);
            try
            {
                var response = await httpClient.PostAsync(Constants.HostName + "/product/scanItem", new StringContent(content, Encoding.UTF8, "application/json"));

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    string body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + body);
                    JObject jObj = JObject.Parse(body);

                    if (jObj != null)
                    {
                        barcode = (string)jObj.SelectToken("Barcode"); // Should be the same
                        string productName = (string)jObj.SelectToken("ProductName");
                        string description = (string)jObj.SelectToken("Description");
                        int amount = 1; 
                        double price = (double)jObj.SelectToken("Price");


                        product = new Product(barcode, productName, description, amount, price);

                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");

            }

            // If registration was incomplete we return false
            return product; // Caller should perform nullcheck in case no product is fetched / barcode is invalid

        }

        public async Task<bool> Login(string email, string password)
        {
            var post = new Customer()
            {
                Email = email,
                Password = password
            };

            var content = JsonConvert.SerializeObject(post);
            Console.WriteLine(content);
            try
            {
                var response = await httpClient.PostAsync(Constants.HostName + "/account/login", new StringContent(content, Encoding.UTF8, "application/json"));

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    string body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + body);
                    JObject jObj = JObject.Parse(body);
                    if (jObj != null)
                    {
                        bool authProp = (bool)jObj.SelectToken("authorized");
                        // We store this preferences for later use 
                        Preferences.Set(GlobalKeys.AuthorizedKey, authProp);

                    }
                    // If login was a sucess we return true
                    return true;
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

            // If login was incomplete we return false
            return false;
        }

        public async Task<bool> Register(string name, string email, string password, string phoneNo)
        {
            var post = new Customer()
            {
                Name = name,
                Email = email,
                Password = password,
                PhoneNumber = phoneNo
            };

            var content = JsonConvert.SerializeObject(post);
            Console.WriteLine(content);
            try
            {
                var response = await httpClient.PostAsync(Constants.HostName + "/account/register", new StringContent(content, Encoding.UTF8, "application/json"));

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    string body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + body);
                    JObject jObj = JObject.Parse(body);
                    if (jObj != null)
                    {
                        bool authProp = (bool)jObj.SelectToken("authorized");

                        // We store this preferences for later use 
                        Preferences.Set(GlobalKeys.AuthorizedKey, authProp);

                    }
                    // If registration was a sucess we return true
                    return true;
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

            // If registration was incomplete we return false
            return false;
        }

        public async Task<HttpResponseMessage> CreateOrder(Order order) {
            using (var httpClient = new HttpClient { BaseAddress = new Uri(Constants.HostName) }) {
                string jsonOrder = JsonConvert.SerializeObject(order);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/order/create");
                request.Content = new StringContent(jsonOrder, Encoding.UTF8, "application/json");

                return await httpClient.SendAsync(request);
            }
        }
    }
}
