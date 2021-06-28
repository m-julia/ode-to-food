using Microsoft.AspNetCore.Mvc;
using OdeToFoodData;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponet : ViewComponent
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantCountViewComponet(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IViewComponentResult Invoke()
        {
            int count = _restaurantData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
