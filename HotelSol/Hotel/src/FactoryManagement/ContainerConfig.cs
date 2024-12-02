using Autofac;
using HotelLibrary;
using Hotel.src.MenuManagement.Interfaces;
using Hotel.src.MenuManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.FactoryManagement
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Menu>().As<IMenu>();

            // Library
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(HotelLibrary)))
                .Where(t => t.Namespace.Contains(nameof(HotelLibrary.Utilities)))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));


            return builder.Build(); ;
        }
    }
}
