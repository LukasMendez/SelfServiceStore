using System;
using System.Threading;
using SelfServiceApp.Helpers;
using SelfServiceApp.ViewModels;
using SelfServiceApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SelfServiceApp.Services
{
    public static class UserLoginService
    {


        public static void SignOut()
        {
            ClearData();
            App.Current.MainPage = new LoginView();
            
        }

        public static void SignIn(string email)
        {
            Preferences.Set(GlobalKeys.EmailKey, email);
            Preferences.Set(GlobalKeys.AuthorizedKey, true);
        }

        public static bool AuthorizedWithInfo()
        {
            bool auth = Preferences.Get(GlobalKeys.AuthorizedKey, false);
            bool email = !Preferences.Get(GlobalKeys.EmailKey, "null").Equals("null");

            if(auth && email)
            {
                return true;
            }

            return false;
        }

        private static void ClearData()
        {
            Preferences.Clear();
        }

        



    }
}
