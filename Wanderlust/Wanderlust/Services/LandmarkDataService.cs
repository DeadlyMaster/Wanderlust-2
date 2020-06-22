using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Models;

namespace Wanderlust.Services
{
    public class LandmarkDataService : ILandmarkDataService
    {
        private readonly ILandmarkRepository _landmarkRepository;

        public LandmarkDataService(ILandmarkRepository landmarkRepository)
        {
            _landmarkRepository = landmarkRepository;
        }
        public async Task AddLandmarkAsync(Landmark landmark)
        {
            await _landmarkRepository.AddLandmarkAsync(landmark);
        }
        public async Task DeleteLandmarkAsync(int id)
        {
            await _landmarkRepository.DeleteLandmarkAsync(id);
        }
        public async Task<Landmark> GetLandmarkAsync(int id)
        {
            return await _landmarkRepository.GetLandmarkAsync(id);
        }
        public async Task<List<Landmark>> GetLandmarksAsync(bool force)
        {
            return await _landmarkRepository.GetLandmarksAsync();
        }

        public async Task<List<Landmark>> GetMustSeeLandmarks()
        {
            return await _landmarkRepository.GetMustSeeLandmarksAsync();
        }

        public async Task UpdateLandmarkAsync(Landmark landmark)
        {
            await _landmarkRepository.UpdateLandmarkAsync(landmark);
        }
    }
}
