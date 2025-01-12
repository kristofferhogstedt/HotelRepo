using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;

namespace Hotel.src.FactoryManagement
{
    public class InstanceGenerator
    {
        /// <summary>
        /// Without previousMenu parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="locker"></param>
        /// <returns></returns>
        public static T GetInstance<T>(IInstantiable instance, object locker) where T : new()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new T() as IInstantiable;
                    }
                }
            }
            return (T)instance;
        }

        /// <summary>
        /// With previousMenu parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="locker"></param>
        /// <param name="previousMenu"></param>
        /// <returns></returns>
        public static T GetInstance<T>(IInstantiable instance, object locker, IMenu previousMenu) where T : new()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new T() as IInstantiable;
                    }
                }
            }
            instance.PreviousMenu = previousMenu;
            return (T)instance;
        }
    }
}
