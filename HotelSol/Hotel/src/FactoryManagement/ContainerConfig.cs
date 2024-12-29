using Autofac;
using Hotel.src.Interfaces;
using Hotel.src.MenuManagement.Interfaces;
using Hotel.src.MenuManager;

namespace Hotel.src.FactoryManagement
{
    /// <summary>
    /// AutoFac
    /// </summary>
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<DatabaseLair>().As<IDatabaseLair>().SingleInstance();
            builder.RegisterType<App>().As<IApp>().SingleInstance();
            builder.RegisterType<MainMenu>().As<IMenu>().SingleInstance();


            //builder.RegisterType<Class>().As<IClass>().SingleInstance();


            //  builder.RegisterType<Class>().As<IClass>();
            //builder.RegisterType<DataAccess>().As<IDataAccess>();
            //builder.RegisterType<Logger>().As<ILogger>();

            // Library
            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(HotelLibrary)))
            //    .Where(t => t.Namespace.Contains(nameof(HotelLibrary.Utilities)))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
