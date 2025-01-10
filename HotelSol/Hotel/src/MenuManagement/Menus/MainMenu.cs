using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    public class MainMenu : IMenu, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();

        public MainMenu()
        {
        }

        public static IMenu GetInstance(IMenu previousMenu)
        {
            _instance = FactoryManagement.InstanceGenerator.GetInstance<MainMenu>(_instance, _lock, previousMenu);

            return (MainMenu)_instance;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<MainMenuOptions>()
                        .Title("Huvudmeny")
                        .UseConverter(option => option.ShowMainMenu())
                        .AddChoices(Enum.GetValues<MainMenuOptions>())
                    );

                switch (option)
                {
                    case MainMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case MainMenuOptions.BookingManagement:
                        IMenu _bookingMenu = MenuFactory.GetMenu<BookingMenu>(this);
                        _bookingMenu.Run();
                        break;
                    case MainMenuOptions.CustomerManagement:
                        IMenu _customerMenu = MenuFactory.GetMenu<CustomerMenu>(this);
                        _customerMenu.Run();
                        break;
                    case MainMenuOptions.RoomManagement:
                        IMenu _roomMenu = MenuFactory.GetMenu<RoomMenu>(this);
                        _roomMenu.Run();
                        break;
                    case MainMenuOptions.InvoiceManagement:
                        IMenu _invoiceMenu = MenuFactory.GetMenu<InvoiceMenu>(this); ;
                        _invoiceMenu.Run();
                        break;
                    //case MainMenuOptions.CleaningManagement:
                    //    IMenu _cleaningMenu = CleaningMenu.GetInstance(this);
                    //    _cleaningMenu.Run();
                    //    break;
                    case MainMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }
        public static void ReturnToMainMenu()
        {
            var _mainMenu = MenuFactory.GetMenu<MainMenu>();
            _mainMenu.Run();
        }
    }
}
