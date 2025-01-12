using Autofac;
using Hotel.src.FactoryManagement;
using Hotel.src.Interfaces;

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
}
