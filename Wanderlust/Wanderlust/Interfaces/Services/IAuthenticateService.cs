﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Models;

namespace Wanderlust.Interfaces.Services
{
    public interface IAuthenticateService
    {
        Task<User> GetUserAsync(string username);

        Task<int> RegisterUser(User user);
    }
}
