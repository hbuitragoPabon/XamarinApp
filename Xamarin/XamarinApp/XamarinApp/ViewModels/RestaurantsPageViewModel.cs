using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XamarinApp.Interfaces;
using XamarinApp.Models;
using XamarinApp.Repositories;

namespace XamarinApp.ViewModels
{
    public class RestaurantsPageViewModel : BaseViewModel
    {
        private bool _IsRefresing;
        public bool IsRefresing { 
        get { return _IsRefresing; }
        set
            {
                _IsRefresing = value;
                OnPropertyChanged("IsRefresing");
            }
        }

        
        public ObservableCollection<RestaurantModel> Restaurantes { get; set; }
        
        public RestaurantsPageViewModel()
        {
            Restaurantes = new ObservableCollection<RestaurantModel>();
            LoadRestaurants();
        }

        async private void LoadRestaurants()
        {
          
                IsRefresing = true;
                foreach (var item in await new RestaurantRepository().GetRestaurants())
                {
                    Restaurantes.Add(item);
                }
                IsRefresing = false;
            
            
            

        }

        
    }
}
