using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Wanderlust.Models;
using Wanderlust.Services;
using Wanderlust.Utility;
using Xamarin.Forms;

namespace Wanderlust.ViewModels
{
    public class LandmarkOverviewViewModel : BaseViewModel
    {
        private ObservableCollection<Landmark> _landmarks;

        private ILandmarkDataService _landmarkDataService;
        private INavigationService _navigationService;
        private IDialogService _dialogService;
        public ICommand LoadCommand { get; }

        public ICommand AddCommand { get; }

        public ICommand LandmarkSelectedCommand { get; }

        public ObservableCollection<Landmark> Landmarks
        {
            get => _landmarks;
            set
            {
                _landmarks = value;
                OnPropertyChanged("Landmarks");
            }
        }

        public LandmarkOverviewViewModel(ILandmarkDataService landmarkDataService, INavigationService navigationService, IDialogService dialogService)
        {
            Landmarks = new ObservableCollection<Landmark>();
            _landmarkDataService = landmarkDataService;
            _navigationService = navigationService;
            _dialogService = dialogService;

            LoadCommand = new Command(OnLoadCommand);
            AddCommand = new Command(OnAddCommand);
            LandmarkSelectedCommand = new Command<Landmark>(OnLandmarkSelectedCommand);

            MessagingCenter.Subscribe<LandmarkDetailViewModel, Landmark>
                (this, MessageNames.LandmarkChangedMessage, OnLandmarkChanged); 
        }

        private async void OnLandmarkChanged(LandmarkDetailViewModel sender, Landmark landmark)
        {
            Landmarks = new ObservableCollection<Landmark>(await _landmarkDataService.GetLandmarksAsync(true)); // aici nu se reinacarca lista de landmarks
        }

        public async void OnLoadCommand()
        {

            //try
            //{
            //    Landmarks = new ObservableCollection<Landmark>(await _landmarkDataService.GetLandmarksAsync(true));
            //}
            //catch(Exception e)
            //{
            //    //await _dialogService.Showdialog(e.Message, "An error has occured", "OK");
            //}

            Landmarks = new ObservableCollection<Landmark>(await _landmarkDataService.GetLandmarksAsync(true));
        }

        private void OnAddCommand()
        {
            //_navigationService.NavigateTo(ViewNames.LandmarkDetailView);
            // add to journey TODO
        }

        private void OnLandmarkSelectedCommand(Landmark landmark)
        {
            _navigationService.NavigateTo(ViewNames.LandmarkDetailView, landmark);
        }
    }
}
