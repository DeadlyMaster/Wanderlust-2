using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wanderlust.Models
{
    public interface IJourneyRepository
    {
        Task<List<Journey>> GetJourneysAsync(string uri);
        Task<Journey> GetJourneyAsync(int id);
        Task AddJourneyAsync(Journey journey);
        Task UpdateJourneyAsync(Journey journey);
        Task DeleteJourneyAsync(int id);
        Task AddToJourneyAsync(string uri, Visit visit);
    }
}
