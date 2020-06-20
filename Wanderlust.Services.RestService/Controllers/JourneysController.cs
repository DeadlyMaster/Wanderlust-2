using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wanderlust.Services.API.Models;

namespace Wanderlust.Services.API.Controllers
{
    [Route("api/[controller]")]
    public class JourneysController : Controller
    {
        private readonly IJourneyRepository _journeyRepository;

        public JourneysController(IJourneyRepository journeyRepository)
        {
            _journeyRepository = journeyRepository;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetItemsForUser(int userId)
        {
            // get the journeys
            var journeys = await _journeyRepository.GetJourneysByUserId(userId);
            return Ok(journeys);
        }


        [HttpPost]
        // get controller
        public async Task<IActionResult> Add([FromBody]Visit visit)
        {
            // get the right journey
            var sight = await _journeyRepository.AddToExistingJourney(visit);
            return Ok(sight);
        }

        [HttpGet]
        public async Task<IActionResult> GetJourneys()
        {
            var journeys = await _journeyRepository.GetJourneys();
            return Ok(journeys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJourney(int id)
        {
            var journey = await _journeyRepository.GetJourney(id);
            return Ok(journey);
        }

        [HttpPost]
        public async Task<IActionResult> AddJourney([FromBody] Journey journey)
        {
            if (journey == null)
                return BadRequest();

            if (journey.JourneyName == string.Empty)
            {
                ModelState.AddModelError("Journey Name", "The journey's name cannot be empty!");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdJourney = await _journeyRepository.AddJourney(journey);

            return Created("journey", createdJourney);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJourney([FromBody] Journey journey)
        {
            if (journey == null)
                return BadRequest();

            if (journey.JourneyName == string.Empty)
            {
                ModelState.AddModelError("Journey Name", "The journey name cannot be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var journeyToUpdate = await _journeyRepository.GetJourney(journey.JourneyId);

            if (journeyToUpdate == null)
                return NotFound();

            await _journeyRepository.UpdateJourney(journey);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJourney(int id)
        {
            if (id <= 0)
                return BadRequest();

            var journeyToDelete = await _journeyRepository.GetJourney(id);
            if (journeyToDelete == null)
                return NotFound();

            await _journeyRepository.DeleteJourney(id);

            return NoContent(); //success
        }
    }
}
