using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoodData
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _contex;

        public SqlRestaurantData(OdeToFoodDbContext contex)
        {
           _contex = contex;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _contex.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return _contex.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            Restaurant restaurant = GetById(id);
            if(restaurant != null )
            {
                _contex.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return _contex.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return _contex.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            var newRestaurants = from r in _contex.Restaurants
                                 select r;

            if (!String.IsNullOrEmpty(name))
            {
                newRestaurants = _contex.Restaurants.Where(s => s.Name.Contains(name));
                return newRestaurants;
            }
            newRestaurants = _contex.Restaurants.OrderBy(r => r.Name);

            return newRestaurants;

        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var chanchedRestaurant = _contex.Restaurants.Attach(updatedRestaurant);
            chanchedRestaurant.State = EntityState.Modified;
            return updatedRestaurant;

        }
    }
}
