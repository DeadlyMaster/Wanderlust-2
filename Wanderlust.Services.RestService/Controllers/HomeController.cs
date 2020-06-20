using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wanderlust.Services.API.Models;

namespace Wanderlust.Services.API.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {

        private readonly ILandmarkRepository _landmarkRepository;

        public HomeController(ILandmarkRepository landmarkRepository)
        {
            _landmarkRepository = landmarkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMustSeeLandmarks()
        {
            var landmarks = await _landmarkRepository.getMustSeeLandmarks();
            return Ok(landmarks); // status 200 and landmarks as json
        }

    }
}
