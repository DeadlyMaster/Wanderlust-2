using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderlust.Models
{
    public class Journey
    {
        public int JourneyId { get; set; }
        public string JourneyName { get; set; }

        public List<Sight> Sights { get; set; }

        public int User { get; set; }
    }
}
