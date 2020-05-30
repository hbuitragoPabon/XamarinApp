using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XamarinApp.Interfaces;
using XamarinApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(StorageService))]
namespace XamarinApp.Services
{

    public class StorageService : IStorageService
    {
        async public Task<string> Get(string key)
        {
            try
            {
                var value = await SecureStorage.GetAsync(key);
                return value;
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
            return null;
        }

        async public void Set(string key, string value)
        {            
            try
            {
                await SecureStorage.SetAsync(key, value);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }
    }
}
