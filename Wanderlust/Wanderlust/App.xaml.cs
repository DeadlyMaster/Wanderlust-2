using System;
using Wanderlust.Essentials;
using Wanderlust.Models;
using Wanderlust.Repository;
using Wanderlust.Services;
using Wanderlust.Utility;
using Wanderlust.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wanderlust
{
    public partial class App : Application
    {
        //singleton - one data service instance
        public static LandmarkDataService LandmarkDataService { get; set; } = new LandmarkDataService(new LandmarkRepository());
        public static NavigationService NavigationService { get; } = new NavigationService();

        public static JourneyDataService JourneyDataService { get; set; } = new JourneyDataService(new JourneyRepository());

        public static DialogService DialogService { get; set; } = new DialogService();

        public static AuthenticateService AuthenticateService { get; set; } = new AuthenticateService();

        public static UserDataService UserDataService { get; set; } = new UserDataService(new UserRepository());

        public App()
        {
            InitializeComponent();

            NavigationService.Configure(ViewNames.LandmarkOverviewView, typeof(LandmarkOverviewView));
            NavigationService.Configure(ViewNames.LandmarkDetailView, typeof(LandmarkDetailView));
            NavigationService.Configure(ViewNames.HomePageView, typeof(HomePageView));
            NavigationService.Configure(ViewNames.LoginPageView, typeof(LoginPageView));
            NavigationService.Configure(ViewNames.JourneyOverviewView, typeof(JourneyOverviewView));
            NavigationService.Configure(ViewNames.JourneyDetailView, typeof(JourneyDetailView));

            MainPage = new NavigationPage(new LoginPageView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
