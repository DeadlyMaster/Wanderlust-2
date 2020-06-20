using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Models;

namespace Wanderlust.Services
{
    public interface IJourneyDataService
    {

        //return the list of journeys
        Task<List<Journey>> GetJourneysAsync(int userId);

        // adds a sight to the selected journey
        Task<Sight> AddSightAsync(Sight sight, int userId);

        
        Task AddJourneyAsync(Journey journey); // create a journey
        Task UpdateJourneyAsync(Journey journey);
        Task DeleteJourneyAsync(int id);
        Task<Journey> GetJourneyAsync(int id);
    }
}
