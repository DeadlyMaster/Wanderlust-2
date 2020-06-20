using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Wanderlust.Models;
using Wanderlust.Services;
using Wanderlust.Utility;
using Xamarin.Forms;

namespace Wanderlust.ViewModels
{
    public class LandmarkDetailViewModel : BaseViewModel
    {

        private Landmark _selectedLandmark;

        private ILandmarkDataService _landmarkDataService;
        private INavigationService _navigationService;

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }


        public Landmark SelectedLandmark
        {
            get { return _selectedLandmark; }
            set
            {
                _selectedLandmark = value;
                OnPropertyChanged("SelectedLandmark");
            }
        }

        public LandmarkDetailViewModel(ILandmarkDataService landmarkDataService, INavigationService navigationService)
        {
            _landmarkDataService = landmarkDataService;
            _navigationService = navigationService;

            SelectedLandmark = new Landmark();
            SaveCommand = new Command(OnSaveCommand);
            DeleteCommand = new Command(OnDeleteCommand);
        }

        private void OnDeleteCommand()
        {
             _landmarkDataService.DeleteLandmarkAsync(SelectedLandmark.LandmarkId);

            MessagingCenter.Send(this, MessageNames.LandmarkChangedMessage, SelectedLandmark);

            _navigationService.GoBack();
        }

        private void OnSaveCommand()
        {
            if (SelectedLandmark.LandmarkId == 0)
                _landmarkDataService.AddLandmarkAsync(SelectedLandmark);
            else
                _landmarkDataService.UpdateLandmarkAsync(SelectedLandmark);

             MessagingCenter.Send(this, MessageNames.LandmarkChangedMessage, SelectedLandmark);

            _navigationService.GoBack();
        }

        public override void Initialize(object parameter)
        {
            if (parameter == null)
                SelectedLandmark = new Landmark();
            else
                SelectedLandmark = parameter as Landmark;
        }
    }
}
