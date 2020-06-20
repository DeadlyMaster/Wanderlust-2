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
    //public class LandmarkOverviewViewTests
    //{
    //    [Fact]
    //    public void Landmarks_Not_Null_After_Construction()
    //    {
    //        var mockNavigationService = new Mock<INavigationService>();
    //        var mockLandmarkDataService = new MockLandmarkDataService();

    //        var landmarkOverviewViewModel = new LandmarkOverviewViewModel(mockLandmarkDataService, mockNavigationService.Object);
    //        Assert.NotNull(landmarkOverviewViewModel.Landmarks);
    //    }

    //    [Fact]
    //    public void Landmarks_Loaded_After_Load_Command()
    //    {
    //        var mockNavigationService = new Mock<INavigationService>();
    //        var mockLandmarkDataService = new MockLandmarkDataService();

    //        var landmarkOverviewViewModel = new LandmarkOverviewViewModel(mockLandmarkDataService, mockNavigationService.Object);
    //        landmarkOverviewViewModel.OnLoadCommand();
    //        //var landmarks = landmarkOverviewViewModel.Landmarks;

    //        Assert.NotNull(landmarkOverviewViewModel.Landmarks);
    //        Assert.Equal(10, landmarkOverviewViewModel.Landmarks.Count);
    //    }
    //}
}
