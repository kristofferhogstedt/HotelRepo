using Autofac;
using Hotel.src.Interfaces;
using Hotel.src.MenuManagement.Menus;
using Hotel.src.MenuManagement.Menus.Interfaces;

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

            builder.RegisterType<App>().As<IApp>().SingleInstance();
            builder.RegisterType<MainMenu>().As<IMenu>().SingleInstance();

            return builder.Build();
        }
    }
}
