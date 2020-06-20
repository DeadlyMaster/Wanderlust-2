using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderlust.Utility
{
    public class ApiConstants
    {
        public const string BaseApiUrl = "https://10.0.2.2:5001/"; 
        public const string LandmarkApiUrl = BaseApiUrl + "api/landmarks";
        public const string MustSeeLandmarkApiUrl = BaseApiUrl + "api/home";
        public const string JourneyApiUrl = BaseApiUrl + "api/journeys";
    }
}
