using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderlust.Models
{
    public class City : BaseModel
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public override string ToString()
        {
            return CityName;
        }
    }
}
