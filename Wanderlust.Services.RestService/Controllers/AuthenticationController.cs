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

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(string firstName, string lastName, string email, string userName, string password)
        {
            if (userName == null || firstName == null || lastName == null || email == null)
                return BadRequest();

            //maybe create a switch here
            if (userName == string.Empty || firstName == string.Empty || lastName == string.Empty || email == string.Empty || password == string.Empty)
            {
                ModelState.AddModelError("Validation", "The UserName Email FirstName LastName Password cannot be empty");
            }

            var createdUser = new User()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                UserName = userName
            };

            createdUser = await _userRepository.AddUser(createdUser);

            return Ok(new AuthenticationResponse
            {
                IsAuthenticated = true,
                User = createdUser
            });
        }





        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> AddUser([FromBody] User user) // registration - this will be called for register
        //{
        //    if (user == null)
        //        return BadRequest();

        //    if (user.Email == string.Empty)
        //    {
        //        ModelState.AddModelError("User Email", "The email cannot be empty");
        //    }

        //    //if (user.Password == string.Empty)
        //    //{
        //    //    ModelState.AddModelError("User Password", "The password cannot be empty");
        //    //}

        //    if (!ModelState.IsValid) // model binding may fail
        //        return BadRequest(ModelState);

        //    var createdUser = await _userRepository.AddUser(user);

        //    return Created("user", createdUser);
        //}
    }
}
