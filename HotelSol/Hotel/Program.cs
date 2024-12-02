using Autofac;
using Hotel.src;
using Hotel.src.FactoryManagement;
using Hotel.src.Interfaces;
using HotelLibrary;
using HotelLibrary.Interfaces;

namespace Hotel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _container = ContainerConfig.Configure();

            using (var scope = _container.BeginLifetimeScope())
            {
                var _app = scope.Resolve<IApp>();
                _app.Run();
            }

            Console.ReadKey();
        }
    }

    // Att göra:
    // DI with AutoFac, Tim Corey https://www.youtube.com/watch?v=mCUNrRtVVWY
    // Använd primary constructor för dependency injection
}
