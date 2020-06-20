using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wanderlust.Services.API.Models
{
    public interface ILandmarkRepository
    {
        Task<IEnumerable<Landmark>> GetLandmarks();
        Task<Landmark> GetLandmark(int id);
        Task<Landmark> AddLandmark(Landmark landmark);
        Task UpdateLandmark(Landmark landmark);
        Task DeleteLandmark(int id);
        Task<IEnumerable<Landmark>> getMustSeeLandmarks();

    }
}
