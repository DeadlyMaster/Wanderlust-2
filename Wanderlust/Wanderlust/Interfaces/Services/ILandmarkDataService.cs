using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Models;

namespace Wanderlust.Services
{
    public interface ILandmarkDataService
    {
        Task<List<Landmark>> GetLandmarksAsync(bool force);
        Task<List<Landmark>> GetMustSeeLandmarks();
        Task AddLandmarkAsync(Landmark landmark);
        Task UpdateLandmarkAsync(Landmark landmark);
        Task DeleteLandmarkAsync(int id);
        Task<Landmark> GetLandmarkAsync(int id);
    }
}
