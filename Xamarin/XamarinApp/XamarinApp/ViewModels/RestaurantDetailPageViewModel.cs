using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinApp.Interfaces;
using XamarinApp.Models;
using XamarinApp.Repositories;

namespace XamarinApp.ViewModels
{
    public class RestaurantDetailPageViewModel : BaseViewModel
    {
        public ICommand OpenUrlCommand { get; set; }

        public ICommand OpenPhoneCommand { get; set; }
        public ObservableCollection<ProductModel> Products { get; set; }
        
        public RestaurantModel Item { get; set; }

        public RestaurantDetailPageViewModel(RestaurantModel item)
        {
            OpenUrlCommand = new Command(OpenUrl);
            OpenPhoneCommand = new Command(OpenPhone);
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

        private void OpenUrl()
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            deviceService.OpenBrowser(Item.SitioWeb);
        }

        private void OpenPhone()
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            deviceService.OpenPhone(Item.Telefono);
        }


    }
}
