using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Interfaces.Services;
using Wanderlust.Models;

namespace Wanderlust.Services
{

    public class AuthenticateService : IAuthenticateService
    {
        public Task<User> GetUserAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<int> RegisterUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
