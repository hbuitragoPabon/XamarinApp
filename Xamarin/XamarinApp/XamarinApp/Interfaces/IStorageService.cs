using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.Interfaces
{
    public interface IStorageService
    {
        Task<string> Get(string key);

        void Set(string key,string value);
    }
}
