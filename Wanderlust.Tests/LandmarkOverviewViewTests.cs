using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Wanderlust.Services;
using Wanderlust.Tests.Mocks;
using Wanderlust.ViewModels;
using Xunit;

namespace Wanderlust.Tests
{
    public class LandmarkOverviewViewTests
    {
        [Fact]
        public void Landmarks_Init_After_Contruction()
        {
            var mockNavigationService = new Mock<INavigationService>();
            var mockdialogService = new Mock<IDialogService>();
            var mockLandmarkDataService = new MockLandmarkDataService();

            var landmarkOverviewViewModel = new LandmarkOverviewViewModel(mockLandmarkDataService, 
                mockNavigationService.Object, mockdialogService.Object);
            landmarkOverviewViewModel.Initialize(null);

            Assert.NotNull(landmarkOverviewViewModel.Landmarks);

            Assert.NotNull(landmarkOverviewViewModel.LoadCommand);
        }

        [Fact]
        public void Home_Not_null_After_Construction()
        {
            var mockNavigationService = new Mock<INavigationService>();
            var mockdialogService = new Mock<IDialogService>();
            var mockLandmarkDataService = new MockLandmarkDataService();

            var homeViewModel = new HomeViewModel(mockLandmarkDataService, mockNavigationService.Object, mockdialogService.Object);
            homeViewModel.Initialize(null);

            Assert.NotNull(homeViewModel.MustSeeLandmarks);
            Assert.Equal(5, homeViewModel.MustSeeLandmarks.Count);
            // command initilized
            Assert.NotNull(homeViewModel.MyJourneyCommand);
        }


        [Fact]
        public void Landmarks_Loaded_After_Load_Command()
        {
            var mockNavigationService = new Mock<INavigationService>();
            var mockdialogService = new Mock<IDialogService>();
            var mockLandmarkDataService = new MockLandmarkDataService();

            var landmarkOverviewViewModel = new LandmarkOverviewViewModel(mockLandmarkDataService, 
                mockNavigationService.Object, mockdialogService.Object);
            landmarkOverviewViewModel.OnLoadCommand();

            Assert.NotNull(landmarkOverviewViewModel.Landmarks);
            Assert.Equal(10, landmarkOverviewViewModel.Landmarks.Count);
        }
    }
}
