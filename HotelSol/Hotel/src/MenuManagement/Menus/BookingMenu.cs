using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    public class BookingMenu : IMenu, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();
        private static IModelController _controller;
        private EModelType _modelType = EModelType.Booking;

        public static IMenu GetInstance(IMenu previousMenu)
        {
            _instance = FactoryManagement.InstanceGenerator.GetInstance<BookingMenu>(_instance, _lock, previousMenu);

            return (BookingMenu)_instance;
        }

        public void Run()
        {
            _controller = ModelFactory.GetModelController(_modelType, this);

            while (true)
            {
                // Sprectre menyval!
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<BookingMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowBookingMenu())
                        //.UseConverter(option => option.GetDescription()) // Visa beskrivningar istället för enum-namn
                        .AddChoices(Enum.GetValues<BookingMenuOptions>())
                    );

                switch (option)
                {
                    case BookingMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case BookingMenuOptions.DisplayBookings:
                        _controller.ReadOne();
                        break;
                    case BookingMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
