using Hotel.src.Models.Services.Interfaces;

namespace Hotel.src.Models.Services
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
