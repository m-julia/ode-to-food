using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFoodData;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            _config = config;
            _restaurantData = restaurantData;
        }

        public void OnGet(string searchTerm)
        {
            Message = _config["Message"];
            Restaurants = _restaurantData.GetRestaurantsByName(searchTerm);
        }
    }
}
