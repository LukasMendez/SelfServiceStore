using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SelfServiceApp.Models;

namespace SelfServiceApp.Services
{
    public interface IWebConnection
    {
        Task<Product> ScanItem(string barcode);
        Task<bool> Login(string email, string password);
        Task<bool> Register(string name, string email, string password, string phoneNo);
    }
}
