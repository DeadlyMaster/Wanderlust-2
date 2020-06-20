using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wanderlust.Services.API.Models
{
    public class Visit
    {
        public int UserId { get; set; }

        public Sight Sight { get; set; }
    }
}
