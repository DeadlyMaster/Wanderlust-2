using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wanderlust.Services.API.Models
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task UpdateUser(User user);
        Task<User> GetUser(int id);
        Task<User> GetUserByEmail(string email);
    }
}
