using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceApp.Models
{
    public class Order
    {
        public int ProductID { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
       
    }
}
