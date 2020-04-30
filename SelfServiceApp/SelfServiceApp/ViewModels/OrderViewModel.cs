using SelfServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SelfServiceApp.ViewModels
{
    public class OrderViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public OrderViewModel() {
            Products = new ObservableCollection<Product>();

            //Test Products
            Products.Add(new Product(10001, "45678914", "mælk", "økologisk", 1, 8.95));
            Products.Add(new Product(10002, "48145414", "rugbrød", "solsikke kerner", 1, 15.95));
            Products.Add(new Product(10003, "87654514", "franskbrød", "fuldkorn", 1, 12.95));
        }
    }
}
