using Hotel.src.ModelManagement.Services.Interfaces;

namespace Hotel.src.ModelManagement.Services
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
