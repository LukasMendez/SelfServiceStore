using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SelfServiceApp.ViewModels;

namespace SelfServiceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            await Task.Delay(5000); //Ka være der ikke er behov for den, alt efter hvor hurtigt det bliver udført, eller kortere tidspunkt

            if (LoginViewModel.LoginSuccess == true)
            {
                await DisplayAlert("Success", "Login Success ", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Username or password no correct ", "OK");
            }

        }
    }
}