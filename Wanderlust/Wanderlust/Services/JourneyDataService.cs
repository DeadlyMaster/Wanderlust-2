using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Models;
using Wanderlust.Utility;

namespace Wanderlust.Services
{
    public class JourneyDataService : IJourneyDataService
    {
        private readonly IJourneyRepository _journeyRepository;

        public JourneyDataService(IJourneyRepository journeyRepository)
        {
            _journeyRepository = journeyRepository;
        }
        public async Task AddJourneyAsync(Journey journey)
        {
            await _journeyRepository.AddJourneyAsync(journey);
        }

        public async Task<Sight> AddSightAsync(Sight sight, int userId)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = $"{ApiConstants.JourneyApiUrl}/{userId}"
            };

            // we create a visit
            var visit = new Visit
            {
                Sight = sight,
                UserId = userId
            };

            await _journeyRepository.AddToJourneyAsync(builder.ToString(), visit);

            // not sure why
            return sight;
        }

        public async Task DeleteJourneyAsync(int id)
        {
            await _journeyRepository.DeleteJourneyAsync(id);
        }

        public async Task<Journey> GetJourneyAsync(int id)
        {
            return await _journeyRepository.GetJourneyAsync(id);
        }

        // we know the user id and we pass further the correct uri for the API call
        public async Task<List<Journey>> GetJourneysAsync(int userId)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = $"{ApiConstants.JourneyApiUrl}/{userId}"
            };

            return await _journeyRepository.GetJourneysAsync(builder.ToString());
        }

        // should have a user id as well....
        public async Task UpdateJourneyAsync(Journey journey)
        {
            await _journeyRepository.UpdateJourneyAsync(journey);
        }
    }
}
