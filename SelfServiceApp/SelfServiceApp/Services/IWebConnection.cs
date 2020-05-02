using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceApp.Services
{
    public interface IWebConnection
    {
        void ScanItem(string barcode);
        void Connect();
        bool Login(string email, string password);
        bool Register(string name, string email, string password, string phoneNo);
    }
}
