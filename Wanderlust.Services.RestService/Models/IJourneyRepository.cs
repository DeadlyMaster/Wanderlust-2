using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wanderlust.Services.API.Models
{
    public interface IJourneyRepository
    {
        Task<IEnumerable<Journey>> GetJourneys();
        Task<Journey> GetJourney(int id);
        Task<Journey> AddJourney(Journey journey);
        Task UpdateJourney(Journey journey);
        Task DeleteJourney(int id);
        Task<Journey> GetUsersJourneys(int userId);
    }
}
