using Wanderlust.Models;
using Wanderlust.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wanderlust.Tests.Mocks
{
    //public class MockLandmarkDataService : ILandmarkDataService
    //{
    //    private List<Landmark> mockLandmarks = new List<Landmark>()
    //    {
    //        new Landmark { LandmarkName = "Apple Pie", LandmarkDescription = "Our famous apple pies!" },
    //        new Landmark { LandmarkName = "Blueberry Cheese Cake", LandmarkDescription = "You'll love it!"},
    //        new Landmark { LandmarkName = "Cheese Cake", LandmarkDescription = "Plain cheese cake. Plain pleasure."},
    //        new Landmark { LandmarkName = "Cherry Pie", LandmarkDescription = "A summer classic!"},
    //        new Landmark { LandmarkName = "Christmas Apple Pie", LandmarkDescription = "Happy holidays with this pie!"},
    //        new Landmark { LandmarkName = "Cranberry Pie", LandmarkDescription = "A Christmas favorite"},
    //        new Landmark { LandmarkName = "Peach Pie", LandmarkDescription = "Sweet as peach"},
    //        new Landmark { LandmarkName = "Pumpkin Pie", LandmarkDescription = "Our Halloween favorite"},
    //        new Landmark { LandmarkName = "Rhubarb Pie", LandmarkDescription = "My God, so sweet!"},
    //        new Landmark { LandmarkName = "Strawberry Pie", LandmarkDescription = "Our delicious strawberry pie!"},
    //     };

    //    public List<Landmark> GetAllLandmarks()
    //    {
    //        return mockLandmarks;
    //    }

    //    public void AddLandmark(Landmark landmark)
    //    {
    //        landmark.LandmarkId = Guid.NewGuid();

    //        mockLandmarks.Add(landmark);
    //    }

    //    public void UpdateLandmark(Landmark landmark)
    //    {
    //        var oldLandmark = mockLandmarks.Where(p => p.LandmarkId == landmark.LandmarkId).FirstOrDefault();
    //        oldLandmark.LandmarkName = landmark.LandmarkName;
    //        oldLandmark.LandmarkDescription = landmark.LandmarkDescription;
    //    }
    //}
}
