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
    public class RoomMenu : IMenu, IInstantiable, IControllable
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();
        public EModelType ModelType { get; set; } = EModelType.Booking;
        public IModelController ModelController { get; set; }

        public static IMenu GetInstance(IMenu previousMenu)
        {
            _instance = FactoryManagement.InstanceGenerator.GetInstance<RoomMenu>(_instance, _lock, previousMenu);

            return (RoomMenu)_instance;
        }
        public void Run()
        {
            ModelController = ModelFactory.GetModelController(ModelType, this);

            while (true)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<RoomMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowRoomMenu())
                        //.UseConverter(option => option.GetDescription()) // Visa beskrivningar istället för enum-namn
                        .AddChoices(Enum.GetValues<RoomMenuOptions>())
                    );

                switch (option)
                {
                    case RoomMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case RoomMenuOptions.DisplayRooms:
                        PreviousMenu.Run();
                        break;
                    case RoomMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
