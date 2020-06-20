using System;
using Wanderlust.Essentials;
using Wanderlust.Models;
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

        public static DialogService DialogService { get; set; } = new DialogService();

        public App()
        {
            InitializeComponent();

            NavigationService.Configure(ViewNames.LandmarkOverviewView, typeof(LandmarkOverviewView));
            NavigationService.Configure(ViewNames.LandmarkDetailView, typeof(LandmarkDetailView));

            MainPage = new NavigationPage(new LandmarkOverviewView());
            //MainPage = new TextToSpeechPage(); // working

            //MainPage = new MapsPage();
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
