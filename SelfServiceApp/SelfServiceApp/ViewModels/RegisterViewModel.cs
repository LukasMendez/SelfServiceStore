using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SelfServiceApp.ViewModels
{

    class RegisterViewModel : BaseViewModel
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

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; this.OnPropertyChanged(); }
        }

        private string phoneNo;
        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; this.OnPropertyChanged(); }
        }

        public ICommand OnRegisterCommand;

        public string Message { get; set; }

        public static bool RegisterDone = false;

        public RegisterViewModel()
        {
            OnRegisterCommand = new Command(async () =>
            {
                var isSuccess = await App.WebConnection.Register(name, email, password, phoneNo);
                if (isSuccess)
                {
                    RegisterDone = true;
                    Message = "Done ... Registration Succesfully";
                    Console.WriteLine(Message);
                    await NavigationService.NavigateToAsync<LoginViewModel>();

                }
                else
                {
                    RegisterDone = false;
                    Message = "Error ... Retry again later :(";
                    Console.WriteLine(Message);
                }
            });

        }


    }
}

