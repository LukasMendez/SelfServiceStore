using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace SelfServiceApp.ViewModels
{
    class LoginViewModel : BaseViewModel
    {

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; this.OnPropertyChanged(); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; this.OnPropertyChanged(); }
        }


        public ICommand OnLoginCommand;

        public LoginViewModel()
        {
            OnLoginCommand = new Command(() =>
            {

            });

        }




    }
}
