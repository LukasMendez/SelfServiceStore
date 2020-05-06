using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SelfServiceApp.Services;

namespace SelfServiceApp.ViewModels
{
    public class BaseViewModel : ExtendedBindableObject
    {


        public BaseViewModel()
        {
         //   NavigationService = ViewModelLocator.Resolve<INavigationService>();
         //   var settingsService = ViewModelLocator.Resolve<ISettingsService>();

        }
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }

}
