using SelfServiceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SelfServiceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterView : ContentPage
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            await Task.Delay(5000); //Ka være der ikke er behov for den, alt efter hvor hurtigt det bliver udført, eller kortere tidspunkt

            if (RegisterViewModel.RegisterDone == true)
            {
                await DisplayAlert("Done", "Done creating new user ", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Problem with creating the new user", "OK");
            }
        }
    }
}