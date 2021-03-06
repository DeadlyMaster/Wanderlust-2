﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wanderlust.Services.API.Models
{
    public class JourneyRepository : IJourneyRepository
    {

        private readonly ApiDbContext _apiDbContext;

        public JourneyRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task<IEnumerable<Journey>> GetJourneysByUserId(int userId)
        {
            return await Task.Factory.StartNew(() =>
            {
                //var journeys = _apiDbContext.Journeys.Include(s => s.Sights).ThenInclude(s => s.Landmark).FirstOrDefault(s => s.User == userId); // one journey
                var journeys = (IEnumerable<Journey>)_apiDbContext.Journeys.Include(s => s.Sights).ThenInclude(s => s.Landmark).Where(s => s.User == userId).ToListAsync();
                //return journeys == null ? new Journey() : journeys; // do not create a new journey if the user does not have one
                return journeys;
            });
        }

        public async Task<Sight> AddToExistingJourney(Visit visit)
        {

            return await Task.Factory.StartNew(() =>
            {
                //var journey = _apiDbContext.Journeys.FirstOrDefault(s => s.User == visit.UserId);
                //search for journey id
                var journey = _apiDbContext.Journeys.FirstOrDefault(s => s.JourneyId == visit.Sight.JourneyId);

                // if it's null than we create a journey
                if (journey == null)
                {
                    journey = new Journey { User = visit.UserId };
                    _apiDbContext.Journeys.Add(journey);
                    _apiDbContext.SaveChanges();
                }

                //get the landmark to be visited
                var landmark = _apiDbContext.Landmarks.FirstOrDefault(l => l.LandmarkId == visit.Sight.LandmarkId);

                var sight = new Sight
                {
                    Landmark = landmark, // not sure if needed
                    LandmarkId = visit.Sight.Landmark.LandmarkId,
                    JourneyId = journey.JourneyId
                };

                _apiDbContext.Sights.Add(sight);
                _apiDbContext.SaveChanges();

                return sight;
            });
        }

        public async Task<Journey> AddJourney(Journey journey)
        {
            return await Task.Factory.StartNew(() =>
            {
                _apiDbContext.Journeys.Add(journey);
                _apiDbContext.SaveChanges();
                return journey;
            });
        }

        public async Task DeleteJourney(int id)
        {
            await Task.Factory.StartNew(() =>
            {
                var journeyToDelete = _apiDbContext.Journeys.Where(l => l.JourneyId == id).FirstOrDefault();
                _apiDbContext.Journeys.Remove(journeyToDelete);
                _apiDbContext.SaveChanges();
            });
        }

        public async Task<Journey> GetJourney(int id)
        {
            return await Task.Factory.StartNew(() => { return _apiDbContext.Journeys.Where(l => l.JourneyId == id).FirstOrDefault(); });
        }

        public async Task<IEnumerable<Journey>> GetJourneys()
        {
            return await Task.Factory.StartNew(() => { return _apiDbContext.Journeys; });
        }

        public async Task UpdateJourney(Journey journey)
        {
            await Task.Factory.StartNew(() =>
            {
                var journeyToUpdate = _apiDbContext.Journeys.Where(j => j.JourneyId
                == journey.JourneyId).FirstOrDefault();

                journeyToUpdate.JourneyName = journey.JourneyName;
                journeyToUpdate.User = journey.User;

                //change list of Landmarks

                _apiDbContext.Journeys.Update(journeyToUpdate);
                _apiDbContext.SaveChanges();
            });
        }
    }
}
