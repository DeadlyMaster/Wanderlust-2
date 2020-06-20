using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wanderlust.Models;
using Wanderlust.Services;
using Xamarin.Forms;

namespace Wanderlust.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private ObservableCollection<Landmark> _mustSeeLandmarks;

        private ILandmarkDataService _landmarkDataService;
        private INavigationService _navigationService;
        private IDialogService _dialogService;

        public HomeViewModel (ILandmarkDataService landmarkDataService, INavigationService navigationService, IDialogService dialogService)
        {
            _landmarkDataService = landmarkDataService;
            _navigationService = navigationService;
            _dialogService = dialogService;

            _mustSeeLandmarks = new ObservableCollection<Landmark>();
        }

        public ObservableCollection<Landmark> MustSeeLandmarks
        {
            get => _mustSeeLandmarks;
            set
            {
                _mustSeeLandmarks = value;
                OnPropertyChanged();
            }
        }

        public override async void Initialize(object parameter)
        {
            MustSeeLandmarks = new ObservableCollection<Landmark> (await _landmarkDataService.GetMustSeeLandmarksAsync());
        }


        public ICommand LandmarkTappedCommand => new Command<Landmark>(OnLandmarkTapped);

        private void OnLandmarkTapped(Landmark obj)
        {
            // go to landmarkDetailView
            throw new NotImplementedException();
        }

        public ICommand AddToJourney => new Command<Landmark>(OnAddToJourney);

        private void OnAddToJourney(Landmark obj)
        {
            throw new NotImplementedException();
        }
    }
}
