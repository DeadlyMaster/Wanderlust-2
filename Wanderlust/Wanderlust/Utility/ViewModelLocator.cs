using System;
using System.Collections.Generic;
using System.Text;
using Wanderlust.ViewModels;

namespace Wanderlust.Utility
{
    public static class ViewModelLocator // in real live apps used with Dependency Injection (IOC container)
    {
        //ne asiguram si ca toate view models sunt intantiate la inceputul rularii
        public static LandmarkOverviewViewModel LandmarkOverviewViewModel { get; set; } = new LandmarkOverviewViewModel(App.LandmarkDataService, App.NavigationService, App.DialogService);
        public static LandmarkDetailViewModel LandmarkDetailViewModel { get; set; } = new LandmarkDetailViewModel(App.LandmarkDataService, App.NavigationService);

        public static LoginViewModel LoginViewModel { get; set; } = new LoginViewModel(App.UserDataService, App.NavigationService);
        public static HomeViewModel HomeViewModel { get; set; } = new HomeViewModel(App.LandmarkDataService, App.NavigationService, App.DialogService);

        public static JourneyViewModel JourneyViewModel { get; set; } = new JourneyViewModel(App.JourneyDataService, App.NavigationService, App.DialogService);
        public static JourneyDetailViewModel JourneyDetailViewModel { get; set; } = new JourneyDetailViewModel(App.JourneyDataService, App.NavigationService);
    }
}
