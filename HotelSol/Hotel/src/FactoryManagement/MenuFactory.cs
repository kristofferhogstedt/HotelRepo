using Hotel.src.MenuManagement.Menus;
using Hotel.src.MenuManagement.Menus.Interfaces;

namespace Hotel.src.FactoryManagement
{
    public class MenuFactory
    {
        public MenuFactory()
        {
        }

        public static T GetMenu<T>() where T : IMenu
        {
            var _typeOfT = typeof(T).Name;
            var _startMenu = StartMenu.GetInstance();

            switch (_typeOfT)
            {
                case nameof(StartMenu):
                    return (T)StartMenu.GetInstance();
                case nameof(MainMenu):
                    return (T)MainMenu.GetInstance(_startMenu);
                default:
                    return default;
            }
        }

        public static T GetMenu<T>(IMenu previousMenu) where T : IMenu
        {
            var _typeOfT = typeof(T).Name;

            switch (_typeOfT)
            {
                case nameof(MainMenu):
                    return (T)MainMenu.GetInstance(previousMenu);
                case nameof(BookingMenu):
                    return (T)BookingMenu.GetInstance(previousMenu);
                case nameof(RoomMenu):
                    return (T)RoomMenu.GetInstance(previousMenu);
                case nameof(CustomerMenu):
                    return (T)CustomerMenu.GetInstance(previousMenu);
                case nameof(InvoiceMenu):
                    return (T)InvoiceMenu.GetInstance(previousMenu);
                default:
                    return default;
            }
        }
    }
}
