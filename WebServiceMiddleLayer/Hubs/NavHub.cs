using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceMiddleLayer.Models;

namespace WebServiceMiddleLayer.Hubs
{
    public class NavHub : Hub
    {
        #region Testing area
        /// <summary>
        /// Example method used for testing purposes. Will be removed in the future
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        #endregion


        #region Main functions

        /// <summary>
        /// This method is used for retrieving the correct item related to the barcode scanned
        /// </summary>
        /// <param name="barcode">the barcode</param>
        /// <returns></returns>
        public async Task ScanItem(string barcode)
        {
            // TODO

            // 1) Find the item with the EAN number

            // 2) Collect all relevant information
            
            // 3) Serialize JSON

            // 4) Send it to Client.Caller 

        }

        /// <summary>
        /// This method is used when the customer is done adding items to his/her order. 
        /// It contains information about the order and the customer who is placing the order. 
        /// </summary>
        /// <param name="orderJSON">a collection of products</param>
        /// <param name="customerInfo">the customer</param>
        /// <returns></returns>
        public async Task Purchase(string orderJSON, string customerInfo)
        {
            // TODO

            // 1) Find the customer in the system to make sure that he exist 

            // 2) Deserialize the order 

            // 3) Perform payment 
            bool paymentSuccess = Payment("123456789");
            if (paymentSuccess)
            {
                // 4) Add the order to the OrderList table in Dynamics 
                
                // 5) Notify Client.Caller that his order went well etc (call a method on the client side) 

            }

        }

        #endregion

        #region Authorization/Authentication
        public async Task Login(string email, string password)
        {
            // 1) Check information

            // 2) If login was success return a token
        }

        public async Task Register(string userInfoJSON)
        {
            // 1) Deserialize user JSON

            // 2) Check if user already exist

            // 3) Hash password (Stuff from Web API project can be reused) 

            // 4) Add customer/user to DB

            // 5) Return token

            CustomerDetail newCustomer = new CustomerDetail() { };

        }

        public async Task ValidateToken(string token)
        {
            // 1) Check if token is valid and not expired

            // 2) Return true or false to client caller

        }




        #endregion



        #region Helper methods
        /// <summary>
        /// This method simulates the idea of a payment, where the user enters his/hers payment information
        /// The method will return true by default as if payment was completed successfully
        /// </summary>
        /// <param name="creditcardInformation"></param>
        /// <returns></returns>
        private bool Payment(string creditcardInformation)
        {
            // Simulates payment.... 

            return true;

        }

        #endregion

    }
}
