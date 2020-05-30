using System;
using System.Collections.Generic;
using System.Text;
using XamarinApp.Interfaces;
using XamarinApp.Services;
using Xamarin.Essentials;


[assembly: Xamarin.Forms.Dependency(typeof(DeviceService))]
namespace XamarinApp.Services
{
    public class DeviceService : IDeviceService
    {
        public bool CkeckConectivity()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                return true;
            }
            return false;
        }

        async public void OpenBrowser(string url)
        {
            await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }

        public void OpenPhone(string telefono)
        {
            PhoneDialer.Open(telefono);
        }
    }
}
