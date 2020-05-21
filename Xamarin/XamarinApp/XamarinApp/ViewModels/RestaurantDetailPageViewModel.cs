using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinApp.Models;
using XamarinApp.Repositories;

namespace XamarinApp.ViewModels
{
    public class RestaurantDetailPageViewModel : BaseViewModel
    {
        public ObservableCollection<ProductModel> Products { get; set; }
        
        public RestaurantModel Item { get; set; }

        public RestaurantDetailPageViewModel(RestaurantModel item)
        {
            Item = item;
            Products = new ObservableCollection<ProductModel>();
            LoadProductos();
        }

        async private void LoadProductos()
        {
            
            foreach (var item in await new RestaurantRepository().GetProducts(Item.Id))
            {
                Products.Add(item);
            }            
        }
    }
}
