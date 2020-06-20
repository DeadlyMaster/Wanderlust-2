using Acr.UserDialogs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Wanderlust.Services;
using Wanderlust.Utility;
using Xamarin.Forms;

namespace Wanderlust.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public ICommand LoginCommand { get; }

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            LoginCommand = new Command(OnLoginCommand);
        }

        private async void OnLoginCommand()
        {
            _navigationService.NavigateTo(ViewNames.HomePageView, MessageNames.UserLoggedIn);
        }


    }
}
