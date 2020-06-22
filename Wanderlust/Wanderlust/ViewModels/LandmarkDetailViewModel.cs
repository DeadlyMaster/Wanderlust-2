using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Wanderlust.Models;
using Wanderlust.Services;
using Wanderlust.Utility;
using Xamarin.Essentials;
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

        public ICommand ReadDescriptionCommand { get; }

        public ICommand MapCommand { get; }


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
            ReadDescriptionCommand = new Command(OnReadDescription);
            MapCommand = new Command(OnMapCommand);
        }

        private void OnMapCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private async void OnReadDescription(object obj)
        {
            try
            {
                var locales = await TextToSpeech.GetLocalesAsync();
                //Locale locale = (Locale)locales.ElementAt(50);

                await TextToSpeech.SpeakAsync(SelectedLandmark.LandmarkDescription, new SpeechOptions()
                {
                    //Locale = locale
                });
            }
            catch (Exception e)
            {
                //isMessageVisible = true;
                //CannotReadText = MessageNames.CannotReadDescription;
            }
        }

        private void OnDeleteCommand()
        {
            _landmarkDataService.DeleteLandmarkAsync(SelectedLandmark.LandmarkId);

            MessagingCenter.Send(this, MessageNames.LandmarkChangedMessage, SelectedLandmark);

            _navigationService.GoBack();
        }

        private async void OnSaveCommand()
        {
            if (SelectedLandmark.LandmarkId == 0)
                await _landmarkDataService.AddLandmarkAsync(SelectedLandmark);
            else
                await _landmarkDataService.UpdateLandmarkAsync(SelectedLandmark);

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
