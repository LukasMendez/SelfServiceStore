using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceApp.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
