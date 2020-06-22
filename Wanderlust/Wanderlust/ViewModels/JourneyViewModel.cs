using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Wanderlust.Models;
using Wanderlust.Services;
using Wanderlust.Utility;
using Xamarin.Forms;

namespace Wanderlust.ViewModels
{
    public class JourneyViewModel : BaseViewModel
    {
        private ObservableCollection<Journey> _journeys;
        private INavigationService _navigationService;
        private IDialogService _dialogService;

        private string _name;
        private int _id;

        public Command LoadCommand { get; }
        public Command AddCommand { get; }
        public Command<Journey> JourneySelectedCommand { get; }

        

        private IJourneyDataService _journeyDataService;

        public ObservableCollection<Journey> Journeys
        {
            get => _journeys;
            set
            {
                _journeys = value;
                OnPropertyChanged("Journeys");
            }
        }

        public JourneyViewModel(IJourneyDataService journeyDataService, INavigationService navigationService, IDialogService dialogService)
        {
            _journeyDataService = journeyDataService;
            _navigationService = navigationService;
            _dialogService = dialogService;


            LoadCommand = new Command(OnLoadCommand);
            AddCommand = new Command(OnAddCommand);
            

            JourneySelectedCommand = new Command<Journey>(OnJourneySelectedCommand);

            MessagingCenter.Subscribe<JourneyDetailViewModel, Journey>
                (this, MessageNames.JourneyChangedMessage, OnJourneyChanged);

            MessagingCenter.Subscribe<JourneyDetailViewModel>
                (this, MessageNames.JourneyDeleteMessage, OnJourneyDeleted);
        }

        private async void OnJourneyDeleted(JourneyDetailViewModel obj)
        {
            Journeys = (await _journeyDataService.GetJourneysAsync(1)).ToObservableCollection(); // user id needed
        }

        private async void OnJourneyChanged(JourneyDetailViewModel sender, Journey journey)
        {
            Journeys = (await _journeyDataService.GetJourneysAsync(1)).ToObservableCollection(); // aici nu se reinacarca lista de landmarks
        }


        public override async void Initialize(object parameter)
        {
            Journeys = (await _journeyDataService.GetJourneysAsync(1)).ToObservableCollection();
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

            Journeys = (await _journeyDataService.GetJourneysAsync(1)).ToObservableCollection(); // need the active user id
        }

        private void OnAddCommand()
        {
            _navigationService.NavigateTo(ViewNames.JourneyDetailView);
        }

        private void OnJourneySelectedCommand(Journey journey)
        {
            _navigationService.NavigateTo(ViewNames.JourneyDetailView, journey);
        }

        public string JourneyName
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("JourneyName");
            }
        }

        public int JourneyId
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("JourneyId");
            }
        }
    }
}
