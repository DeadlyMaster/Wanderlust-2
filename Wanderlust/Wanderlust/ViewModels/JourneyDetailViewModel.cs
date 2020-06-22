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
    public class JourneyDetailViewModel : BaseViewModel
    {
        private Journey _selectedJourney;

        private IJourneyDataService _journeyDataService;
        private INavigationService _navigationService;

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public Command AddLandmark { get; }

        public Journey SelectedJourney
        {
            get { return _selectedJourney; }
            set
            {
                _selectedJourney = value;
                OnPropertyChanged("SelectedJourney");
            }
        }

        public JourneyDetailViewModel(IJourneyDataService journeyDataService, INavigationService navigationService)
        {
            _journeyDataService = journeyDataService;
            _navigationService = navigationService;

            SelectedJourney = new Journey();
            SaveCommand = new Command(OnSaveCommand);
            DeleteCommand = new Command<Journey>(OnDeleteCommand);
            AddLandmark = new Command(OnAddLandmark);
        }

        private void OnAddLandmark(object obj)
        {
            _navigationService.NavigateTo(ViewNames.LandmarkOverviewView);
        }

        private async void OnDeleteCommand(Journey journey)
        {
            journey = _selectedJourney;
            await _journeyDataService.DeleteJourneyAsync(journey.JourneyId);
            MessagingCenter.Send(this, MessageNames.JourneyDeleteMessage);
            //await _navigationService.GoBackAsync();
            _navigationService.GoBack();
        }

        private async void OnSaveCommand()
        {
            if (SelectedJourney.JourneyId == 0)
                await _journeyDataService.AddJourneyAsync(SelectedJourney);
            else
                await _journeyDataService.UpdateJourneyAsync(SelectedJourney);

            MessagingCenter.Send(this, MessageNames.JourneyChangedMessage, SelectedJourney);

            _navigationService.GoBack();
        }

        public override void Initialize(object parameter)
        {
            if (parameter == null)
                SelectedJourney = new Journey();
            else
                SelectedJourney = parameter as Journey;
        }
    }
}
