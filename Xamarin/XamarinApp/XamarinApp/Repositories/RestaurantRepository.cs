using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using XamarinApp.Models;
using System.Threading.Tasks;

namespace XamarinApp.Repositories
{
    public class RestaurantRepository
    {

        async public Task<List<RestaurantModel>> GetRestaurants()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(new
                    Uri("https://cedesistemas-app-api.azurewebsites.net/api/Restaurantes"));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<RestaurantModel>>(content);
                }
            }
            return null;
        }



    }


}
