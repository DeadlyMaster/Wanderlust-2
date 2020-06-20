using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wanderlust.Services.API.Models;

namespace Wanderlust.Services.API.ViewModel
{
    public class AuthenticationResponse
    {
        public bool IsAuthenticated { get; set; }
        public User User { get; set; }
    }
}
