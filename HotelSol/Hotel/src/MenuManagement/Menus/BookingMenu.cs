using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Utilities.Checkers;
using Hotel.src.ModelManagement.Utilities.Messagers;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    public class BookingMenu : IMenu, IInstantiable, IControllable, IHandleInactives
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();
        public EModelType ModelType { get; set; } = EModelType.Booking;
        public IModelController ModelController { get; set; }
        public bool HandleInactive { get; set; }

        public static IMenu GetInstance(IMenu previousMenu)
        {
            _instance = FactoryManagement.InstanceGenerator.GetInstance<BookingMenu>(_instance, _lock, previousMenu);

            return (BookingMenu)_instance;
        }

        public void Run()
        {
            ModelController = ModelFactory.GetModelController(ModelType, this);

            while (true)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<BookingMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowBookingMenu())
                        .AddChoices(Enum.GetValues<BookingMenuOptions>())
                    );

                switch (option)
                {
                    case BookingMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case BookingMenuOptions.DisplayBookings:
                        HandleInactive = false;
                        if (DataElementChecker.CheckBookingDataExists(HandleInactive))
                            ModelController.ManageOne(HandleInactive);
                        else
                            ServiceMessager.DataNotFoundMessage();
                        break;
                    case BookingMenuOptions.CreateBooking:
                        ModelController.Create();
                        break;
					case BookingMenuOptions.DisplayInactive:
						HandleInactive = true;
                        if (DataElementChecker.CheckBookingDataExists(HandleInactive))
                            ModelController.ManageOne(HandleInactive);
                        else 
                            ServiceMessager.DataNotFoundMessage();
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
