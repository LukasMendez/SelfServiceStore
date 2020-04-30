using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace SelfServiceApp.ViewModels
{
    class LoginViewModel : BaseViewModel
    {

        bool isBusy = false;

        // Navigates to the Startpage
        public ICommand NavigateToSentenceCMD => new Command(async () => {
            if (isBusy)
                return;
            isBusy = true;

            //await NavigationService.NavigateToAsync<HomeViewModel>(); Show the next page then login happen successfully. 

            isBusy = false;
        });


    }
}
