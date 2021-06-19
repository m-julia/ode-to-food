using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoodData
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Pizza", Location = "Prague 10, Francouzska, 489/85", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "U Parashutista", Location = "Prague 2, Karlova, 1089/87", Cuisine = CuisineType.Czech},
                new Restaurant {Id = 3, Name = "New Mexico", Location = "Prague 6, Litova, 12/12", Cuisine = CuisineType.Mexican},
                new Restaurant {Id = 4, Name = "APOLO", Location = "Prague 1, Naplovka, 5", Cuisine = CuisineType.None},
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            // return from r in restaurants
            // orderby r.Name
            // select r;
            List<Restaurant> newRestaurants = restaurants.OrderBy(r => r.Name).ToList();
            return newRestaurants;
        }
    }
}
