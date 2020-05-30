using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using XamarinApp.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.Interfaces;

namespace XamarinApp.Repositories
{
    public class RestaurantRepository
    {

        public IDeviceService DeviceService { get; set; }

        public IStorageService StorageService { get; set; }
        public RestaurantRepository()
        {
            DeviceService = DependencyService.Get<IDeviceService>();
            StorageService = DependencyService.Get<IStorageService>();
        }

        async public Task<List<RestaurantModel>> GetRestaurants()
        {
            
            if (DeviceService.CkeckConectivity())
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(new
                        Uri("https://cedesistemas-app-api.azurewebsites.net/api/Restaurantes"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        StorageService.Set("Restaurants", content);
                        return JsonConvert.DeserializeObject<List<RestaurantModel>>(content);
                    }
                }
            }
            else
            {
                string content = await StorageService.Get("Restaurants");                
                return JsonConvert.DeserializeObject<List<RestaurantModel>>(content);
            }    
            return null;
        }

        async public Task<List<ProductModel>> GetProducts(Guid restaurantId)
        {
            if (DeviceService.CkeckConectivity())
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(new
                        Uri($"https://cedesistemas-app-api.azurewebsites.net/api/Restaurantes/{restaurantId}/Productos"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        StorageService.Set($"Products_{restaurantId}", content);
                        return JsonConvert.DeserializeObject<List<ProductModel>>(content);
                    }
                }
            }
            else
            {
                string content = await StorageService.Get($"Products_{restaurantId}");
                return JsonConvert.DeserializeObject<List<ProductModel>>(content);
            }
            return null;
        }


    }


}
