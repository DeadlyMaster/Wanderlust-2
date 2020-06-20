using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wanderlust.Models
{
    interface IJourneyRepository
    {
        Task<List<Journey>> GetJourneysAsync();
        Task<Journey> GetJourneyAsync(int id);
        Task AddJourneyAsync(Journey journey);
        Task UpdateJourneyAsync(Journey journey);
        Task DeleteJourneyAsync(int id);
    }
}
