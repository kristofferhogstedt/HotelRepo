using HotelLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Services
{
    public static class Instancer<T>
    {
        static T? _instance;
        static ICustomerService GetInstance(IInstantiatable<T> classToInstantiate)
        {
            if (classToInstantiate.Instance == null)
                _instance = Factory.GetInstance();
            return _instance;
        }
    }
}
