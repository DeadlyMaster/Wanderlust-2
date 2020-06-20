using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wanderlust.Models
{
    public interface ILandmarkRepository
    {
        Task<List<Landmark>> GetLandmarksAsync();
        Task<Landmark> GetLandmarkAsync(int id);
        Task AddLandmarkAsync(Landmark landmark);
        Task UpdateLandmarkAsync(Landmark landmark);
        Task DeleteLandmarkAsync(int id);
    }
}
