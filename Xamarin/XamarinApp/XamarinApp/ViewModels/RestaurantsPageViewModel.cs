using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinApp.Models;
using XamarinApp.Repositories;

namespace XamarinApp.ViewModels
{
    public class RestaurantsPageViewModel
    {
        public ObservableCollection<RestaurantModel> Restaurantes { get; set; }

        public RestaurantsPageViewModel()
        {
            Restaurantes = new ObservableCollection<RestaurantModel>();
            LoadRestaurants();
        }

        async private void LoadRestaurants()
        {

            foreach (var item in await new RestaurantRepository().GetRestaurants())
            {
                Restaurantes.Add(item);
            }
            

        }
    }
}
