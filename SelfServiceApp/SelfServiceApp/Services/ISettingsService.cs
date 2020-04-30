using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServiceApp.Services
{
    interface ISettingsService
    {
        string AuthAccessToken { get; set; }
        string AuthIdToken { get; set; }

    }
}
