using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public static bool LoginSuccess = false;
        public string Message { get; set; }

        public LoginViewModel()
        {
            OnLoginCommand = new Command(async () =>
            {
                var isLoginSuccess = await App.WebConnection.Login(email, password);
                if (isLoginSuccess)
                {
                    LoginSuccess = true;
                    Message = "Login Successfully";
                    Console.WriteLine(Message);

                    await NavigationService.NavigateToAsync<OrderViewModel>();
                }
                else
                {
                    LoginSuccess = false;
                    Message = "Error ... Retry Again Now or Later";
                    Console.WriteLine(Message);
                }
            });

        }

    }
}
