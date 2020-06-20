using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Models;

namespace Wanderlust.Services
{
    public interface IJourneyDataService
    {
        //Task<ShoppingCart> GetShoppingCart(string userId);
        //Task<ShoppingCartItem> AddShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId);

        Task<List<Journey>> GetJourneysAsync(/*bool force*/ int userId);

        Task<Sight> AddSight(Sight sight, int userId);
        Task AddJourneyAsync(Journey journey); // create a journey
        Task UpdateJourneyAsync(Journey journey);
        Task DeleteJourneyAsync(int id);
        Task<Journey> GetJourneyAsync(int id);
    }
}
