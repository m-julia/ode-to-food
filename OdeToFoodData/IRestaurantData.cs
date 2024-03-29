﻿using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoodData
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
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

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            var newRestaurants = from r in restaurants
                                 select r;

            if (!String.IsNullOrEmpty(name))
            {
                newRestaurants = restaurants.Where(s => s.Name.Contains(name));
                return newRestaurants;
            }
                newRestaurants = restaurants.OrderBy(r => r.Name).ToList();
            
            return newRestaurants;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }
    }
}
