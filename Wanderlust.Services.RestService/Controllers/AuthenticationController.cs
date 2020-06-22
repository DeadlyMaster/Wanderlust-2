using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wanderlust.Services.API.Models;
using Wanderlust.Services.API.ViewModel;

namespace Wanderlust.Services.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //[HttpGet]

        //public async Task<IActionResult> GetUserAsync()
        //{
        //    //var user = await _userRepository.GetUserByEmail(email);
        //    //return Ok(user); // status 200
        //}

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            if (user.Email == string.Empty)
            {
                ModelState.AddModelError("User Email", "The email cannot be empty");
            }

            //if (userName == null || firstName == null || lastName == null || email == null)
            //    return BadRequest();

            ////maybe create a switch here
            //if (userName == string.Empty || firstName == string.Empty || lastName == string.Empty || email == string.Empty || password == string.Empty)
            //{
            //    ModelState.AddModelError("Validation", "The UserName Email FirstName LastName Password cannot be empty");
            //}

            // search for a duplicated email
            var getUser = await _userRepository.GetUserByEmail(user.Email);  

            if (getUser == null)
            {
                //var createdUser = new User()
                //{
                //    Email = email,
                //    FirstName = firstName,
                //    LastName = lastName,
                //    UserName = userName,
                //    Password = password
                //};

                var createdUser = await _userRepository.AddUser(user);

                return Ok(new AuthenticationResponse
                {
                    IsAuthenticated = true,
                    User = createdUser
                });
            }

            //return error
            ModelState.AddModelError("Email", "The email cannot be duplicated!");
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AuthenticateAsync(string userName, string password)
        {
            // getuser by username
            var user = await _userRepository.GetUserByEmail(userName);

            if (user.Password != password)
                ModelState.AddModelError("Authentication", "Password is incorrect!");


            //maybe leave it like this
            return Ok(new AuthenticationResponse
            {
                IsAuthenticated = true,
                User = user
                //User = new User()
                //{
                //    //Id = Guid.NewGuid().ToString(),
                //    Email = "test@something.com",
                //    FirstName = "Gill",
                //    LastName = "Cleeren",
                //    UserName = userName
                //}
            });
        }





        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddUser([FromBody] User user) // registration - this will be called for register
        {
            if (user == null)
                return BadRequest();

            if (user.Email == string.Empty)
            {
                ModelState.AddModelError("User Email", "The email cannot be empty");
            }

            //if (user.Password == string.Empty)
            //{
            //    ModelState.AddModelError("User Password", "The password cannot be empty");
            //}

            if (!ModelState.IsValid) // model binding may fail
                return BadRequest(ModelState);

            var createdUser = await _userRepository.AddUser(user);

            return Created("user", createdUser);
        }
    }
}
