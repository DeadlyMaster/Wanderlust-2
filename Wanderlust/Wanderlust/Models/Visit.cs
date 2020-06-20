using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderlust.Models
{
    public class Visit
    {
        public int UserId { get; set; }

        public Sight Sight { get; set; }
    }
}
