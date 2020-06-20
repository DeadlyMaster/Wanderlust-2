using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Wanderlust.Services.API.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _apiDbContext;

        public UserRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task<User> AddUser(User user)
        {
            return await Task.Factory.StartNew(() =>
            {
                _apiDbContext.Users.Add(user);
                _apiDbContext.SaveChanges(); // maybe it works
                return user;
            });
        }

        public async Task<User> GetUser(int id)
        {
            return await Task.Factory.StartNew(() => { return _apiDbContext.Users.Where(u => u.UserId == id).FirstOrDefault(); });
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await Task.Factory.StartNew(() => { return _apiDbContext.Users.Where(u => u.Email == email).FirstOrDefault(); });
        }

        public async Task UpdateUser(User user)
        {
            await Task.Factory.StartNew(() =>
            {
                var userToUpdate = _apiDbContext.Users.Where(l => l.UserId == user.UserId).FirstOrDefault();
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Email = user.Email;

                _apiDbContext.Users.Update(userToUpdate);
                _apiDbContext.SaveChanges();
            });
        }
    }
}
