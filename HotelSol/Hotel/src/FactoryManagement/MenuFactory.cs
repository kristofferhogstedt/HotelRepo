﻿using Hotel.src.MenuManagement.Menus;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;

namespace Hotel.src.FactoryManagement
{
    public class MenuFactory
    {
        //private IApp _app;

        public MenuFactory()
        {
            //_app = app;
        }

        public static T GetMenu<T>() where T : IMenu
        {
            var _typeOfT = typeof(T).Name;
            //var _typeOfT = typeof(T).ToString();
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
            //var _typeOfT = typeof(T).ToString();
            
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
