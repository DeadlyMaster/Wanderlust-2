using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wanderlust.Services.API.Models
{
    public class Sight
    {
        public int SightId { get; set; }
        public Landmark Landmark { get; set; } // we have the landmark key, we don't need the object
        public int LandmarkId { get; set; }

        // date

        public int JourneyId { get; set; }
    }
}
