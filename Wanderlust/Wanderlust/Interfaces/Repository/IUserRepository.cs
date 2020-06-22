using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Models;

namespace Wanderlust.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string username);

        Task<User> RegisterUser(User user); // string firstName, string lastName, string email, string userName, string password
    }
}
