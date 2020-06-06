﻿using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {

        List<Restaurant> restaurants;


        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id= 1, Name = "Leroy's Pizza", Cuisine = CuisineType.Italian},
                new Restaurant{Id= 2, Name = "Tersiguels", Cuisine = CuisineType.French},
                new Restaurant{Id= 3, Name = "Mango Grove", Cuisine = CuisineType.Indian},
            };

        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Update(Restaurant restaurant)
        {
            //var existingRestaurant = restaurants.FirstOrDefault(r => r.Id == restaurant.Id);
            var existingRestaurant = Get(restaurant.Id);

            if (existingRestaurant != null)
            {
                existingRestaurant.Cuisine = restaurant.Cuisine;
                existingRestaurant.Name = restaurant.Name;
            }

        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy( r => r.Name);
        }

        public void Delete(Restaurant restaurant)
        {
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
        }

        public void Delete(int id)
        {
            var restaurant = Get(id);

            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

        }
    }

}
