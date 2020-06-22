using Acr.UserDialogs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Wanderlust.Interfaces.Services;
using Wanderlust.Services;
using Wanderlust.Utility;
using Xamarin.Forms;

namespace Wanderlust.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IUserDataService _userDataService;

        private string errormsg;
        private string password;
        private string userName;

        public ICommand LoginCommand { get; }

        public LoginViewModel(IUserDataService userDataService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _userDataService = userDataService;

            LoginCommand = new Command(OnLoginCommand);
        }

        private async void OnLoginCommand()
        {
            //try
            //{
            //    Landmarks = new ObservableCollection<Landmark>(await _landmarkDataService.GetLandmarksAsync(true));
            //}
            //catch (Exception e)
            //{
            //    //await _dialogService.Showdialog(e.Message, "An error has occured", "OK");
            //}
            //var user = await _userDataService.GetUserAsync(UserName);
            _navigationService.NavigateTo(ViewNames.HomePageView, MessageNames.UserLoggedIn);
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string ErrorMsg
        {
            get
            {
                return errormsg;
            }
            set
            {
                errormsg = value;
                OnPropertyChanged("ErrorMsg");
            }
        }
    }
}
