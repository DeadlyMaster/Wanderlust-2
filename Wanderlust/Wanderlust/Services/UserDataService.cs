using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Interfaces.Repository;
using Wanderlust.Interfaces.Services;
using Wanderlust.Models;

namespace Wanderlust.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserRepository _userRepository;

        public UserDataService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await _userRepository.GetUserAsync(username);
        }

        public async Task<User> RegisterUser(User user)
        {
            return await _userRepository.RegisterUser(user);
        }
    }
}
