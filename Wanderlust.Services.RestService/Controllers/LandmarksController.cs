using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wanderlust.Services.API.Models;

namespace Wanderlust.Services.API.Controllers
{
    [Route("api/[controller]")]
    public class LandmarksController : Controller
    {
        private readonly ILandmarkRepository _landmarkRepository;

        public LandmarksController(ILandmarkRepository landmarkRepository)
        {
            _landmarkRepository = landmarkRepository;
        }

        [HttpGet]
        //[Route("[action]")]
        public async Task<IActionResult> GetLandmarks()
        {
            var landmarks = await _landmarkRepository.GetLandmarks();
            return Ok(landmarks); // status 200 and landmarks as json
        }

        // need to test if this method works or needs a different path: ex {mustSeeLandmarks}
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetMustSeeLandmarks()
        {
            var landmarks = await _landmarkRepository.getMustSeeLandmarks();
            return Ok(landmarks); // status 200 and landmarks as json
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLandmark(int id)
        {
            var landmark = await _landmarkRepository.GetLandmark(id);
            return Ok(landmark);
        }

        [HttpPost]
        public async Task<IActionResult> AddLandmark([FromBody] Landmark landmark)
        {
            if (landmark == null)
                return BadRequest();

            if (landmark.LandmarkName == string.Empty)
            {
                ModelState.AddModelError("Landmark Name", "The landmark name cannot be empty");
            }

            if (!ModelState.IsValid) // model binding may fail
                return BadRequest(ModelState);

            var createdLandmark = await _landmarkRepository.AddLandmark(landmark);

            return Created("landmark", createdLandmark);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLandmark([FromBody] Landmark landmark)
        {
            if (landmark == null)
                return BadRequest();

            if (landmark.LandmarkName == string.Empty)
            {
                ModelState.AddModelError("Landmark Name", "The landmark name cannot be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var landmarkToUpdate = await _landmarkRepository.GetLandmark(landmark.LandmarkId);

            if (landmarkToUpdate == null)
                return NotFound(); // status 404

            await _landmarkRepository.UpdateLandmark(landmark);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLandmark(int id)
        {
            if (id <= 0)
                return BadRequest();

            var landmarkToDelete = await _landmarkRepository.GetLandmark(id);
            if (landmarkToDelete == null)
                return NotFound();

            await _landmarkRepository.DeleteLandmark(id);

            return NoContent(); //success
        }
    }
}
