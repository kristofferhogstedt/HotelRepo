using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
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

        //public MainMenu(IMenu previousMenu)
        //{
        //    PreviousMenu = previousMenu;
        //}

        public static IMenu GetInstance(IMenu previousMenu)
        {
            _instance = FactoryManagement.InstanceGenerator.GetInstance<MainMenu>(_instance, _lock, previousMenu);

            return (MainMenu)_instance;
            //if (_instance == null)
            //{
            //    lock (_lock)
            //    {
            //        if (_instance == null)
            //        {
            //            _instance = new MainMenu(previousMenu);
            //        }
            //    }
            //}
            //return _instance;
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
                        //.UseConverter(option => option.GetDescription()) // Visa beskrivningar istället för enum-namn
                        .AddChoices(Enum.GetValues<MainMenuOptions>())
                    );

                switch (option)
                {
                    case MainMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case MainMenuOptions.CustomerManagement:
                        IMenu _customerMenu = CustomerMenu.GetInstance(this);
                        _customerMenu.Run();
                        break;
                    case MainMenuOptions.BookingManagement:
                        IMenu _bookingMenu = BookingMenu.GetInstance(this);
                        _bookingMenu.Run();
                        break;
                    case MainMenuOptions.RoomManagement:
                        IMenu _roomMenu = RoomMenu.GetInstance(this);
                        _roomMenu.Run();
                        break;
                    case MainMenuOptions.CleaningManagement:
                        IMenu _cleaningMenu = CleaningMenu.GetInstance(this);
                        _cleaningMenu.Run();
                        break;
                    case MainMenuOptions.EconomyManagement:
                        IMenu _economyMenu = EconomyMenu.GetInstance(this);
                        _economyMenu.Run();
                        break;
                    case MainMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }

                //[Description("Föregående meny")]
                //        PreviousMenu,
                //[Description("Bokningshantering")]
                //        BookingManagement,
                //[Description("Kundhantering")]
                //        CustomerManagement,
                //[Description("Rumhantering")]
                //        RoomManagement,
                //[Description("Admin")]
                //        Admin,
                //[Description("Avsluta")]
            }
        }
    }
}
