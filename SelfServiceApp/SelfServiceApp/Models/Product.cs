using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceApp.Models
{
    public class Product
    {
        public string Barcode { get; set; } // Primary key
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public Product(string barcode, string productName, string description, int amount, double price) {
            this.Barcode = barcode;
            this.ProductName = productName;
            this.Description = description;
            this.Amount = amount;
            this.Price = price;
        }
    }
}
