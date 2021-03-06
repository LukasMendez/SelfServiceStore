﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using SelfServiceApp.Services;
using SelfServiceApp.Views;
using Xamarin.Forms;


namespace SelfServiceApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
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


        public ICommand OnLoginCommand { get; set; }

        public ICommand OnRegisterCommand { get; set; }

        public static bool LoginSuccess = false;
        public string Message { get; set; }

        public LoginViewModel()
        {
            OnLoginCommand = new Command(async () =>
            {
                Console.WriteLine("*Logging in*");
                if(!String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Password))
                {
                    var isLoginSuccess = await App.WebConnection.Login(email, password);
                    if (isLoginSuccess)
                    {
                        LoginSuccess = true;
                        Message = "Login Successfully";
                        Console.WriteLine(Message);
                        // Will sign in and save the email for later use
                        UserLoginService.SignIn(email);

                        App.Current.MainPage = new MainView();
                    }
                    else
                    {
                        LoginSuccess = false;
                        Message = "Error ... Retry Again Now or Later";
                        await App.Current.MainPage.DisplayAlert("Error", "Email or password incorrect. Please try again", "OK");
                        Console.WriteLine(Message);
                    }
                } else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Please make sure to fill all the fields", "OK");
                }
               
            });

            OnRegisterCommand = new Command(() =>
           {
               App.Current.MainPage = new RegisterView();
           });

        }

    }
}
