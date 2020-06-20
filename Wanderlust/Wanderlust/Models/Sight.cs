using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderlust.Models
{
    public class Sight
    {
        public int SightId { get; set; }
        public Landmark Landmark { get; set; } // we have the landmark key, we don't need the object
        public int LandmarkId { get; set; }
        public int JourneyId { get; set; }
    }
}
