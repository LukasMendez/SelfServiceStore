using SelfServiceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SelfServiceApp.Services
{
    public class NavigationService : INavigationService
    {
        private readonly ISettingsService _settingsService;

        public NavigationService(ISettingsService settingsService) {
            _settingsService = settingsService;
        }

        public BaseViewModel PreviousPageViewModel => throw new NotImplementedException();

        public Task InitializeAsync() {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync(Type viewModelType) {
            throw new NotImplementedException();
        }

        public Task RemoveBackStackAsync() {
            throw new NotImplementedException();
        }

        public Task RemoveLastFromBackStackAsync() {
            throw new NotImplementedException();
        }
    }
}
