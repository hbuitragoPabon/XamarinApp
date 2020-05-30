using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp.Interfaces
{
    public interface IDeviceService
    {
        bool CkeckConectivity();
        void OpenBrowser(string url);

        void OpenPhone(string telefono);
    }
}
