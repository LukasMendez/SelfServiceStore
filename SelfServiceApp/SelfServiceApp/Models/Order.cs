using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceApp.Models
{
    public class Order
    {
        public List<Product> Products { get; set; }
        public string Email { get; set; }

        public Order(List<Product> products, string email) {
            this.Products = products;
            this.Email = email;
        }
    }

}
