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
    //public class JourneyOverviewModel : BaseViewModel
    //{
    //    //private ObservableCollection<Journey> _journeys;

    //    //private IJourneyDataService _journeyDataService;
    //    //private INavigationService _navigationService;
    //    //private IDialogService _dialogService;
    //    //public ICommand LoadCommand { get; }

    //    //public ICommand AddCommand { get; }

    //    //public ICommand JourneySelectedCommand { get; }

    //    //public Command AddLandmark { get; }

    //    //public ObservableCollection<Journey> Journeys
    //    //{
    //    //    get => _journeys;
    //    //    set
    //    //    {
    //    //        _journeys = value;
    //    //        OnPropertyChanged("Journeys");
    //    //    }
    //    //}

    //    //public JourneyOverviewModel(IJourneyDataService journeyDataService, INavigationService navigationService, IDialogService dialogService)
    //    //{
    //    //    Journeys = new ObservableCollection<Journey>();
    //    //    _journeyDataService = journeyDataService;
    //    //    _navigationService = navigationService;
    //    //    _dialogService = dialogService;

    //    //    LoadCommand = new Command(OnLoadCommand);
    //    //    AddCommand = new Command(OnAddCommand);
    //    //    JourneySelectedCommand = new Command<Journey>(OnJourneySelectedCommand);
    //    //    AddLandmark = new Command(OnAddLandmark);

    //    //    MessagingCenter.Subscribe<JourneyDetailViewModel, Journey>
    //    //        (this, MessageNames.JourneyChangedMessage, OnJourneyChanged);

    //    //    MessagingCenter.Subscribe<JourneyDetailViewModel>
    //    //        (this, MessageNames.JourneyDeleteMessage, OnJourneyDeleted);
    //    //}

    //    //private async void OnJourneyDeleted(JourneyDetailViewModel obj)
    //    //{
    //    //    Journeys = (await _journeyDataService.GetJourneysAsync(1)).ToObservableCollection(); // user id needed
    //    //}

    //    //private async void OnJourneyChanged(JourneyDetailViewModel arg1, Journey arg2)
    //    //{
    //    //    Journeys = new ObservableCollection<Journey>(await _journeyDataService.GetJourneysAsync(1)); // user id needed
    //    //}

    //    //public async void OnLoadCommand()
    //    //{

    //    //    //try
    //    //    //{
    //    //    //    Landmarks = new ObservableCollection<Landmark>(await _landmarkDataService.GetLandmarksAsync(true));
    //    //    //}
    //    //    //catch(Exception e)
    //    //    //{
    //    //    //    //await _dialogService.Showdialog(e.Message, "An error has occured", "OK");
    //    //    //}

    //    //    Journeys = new ObservableCollection<Journey>(await _journeyDataService.GetJourneysAsync(1)); //user id
    //    //}

    //    //private void OnAddCommand()
    //    //{
    //    //    _navigationService.NavigateTo(ViewNames.JourneyDetailView);
    //    //}

    //    //private void OnJourneySelectedCommand(Journey journey)
    //    //{
    //    //    _navigationService.NavigateTo(ViewNames.JourneyDetailView, journey);
    //    //}
    //}
}
