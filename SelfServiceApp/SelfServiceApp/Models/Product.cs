using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceApp.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public Product(int productID, string barcode, string productName, string description, int amount, double price) {
            this.ProductID = productID;
            this.Barcode = barcode;
            this.ProductName = productName;
            this.Description = description;
            this.Amount = amount;
            this.Price = price;
        }
    }
}
