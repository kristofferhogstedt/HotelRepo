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

namespace Hotel.src.MenuManagement.Menus
{
    public class RoomMenu : IMenu, IInstantiable, IControllable, IHandleInactives
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();
        public EModelType ModelType { get; set; } = EModelType.Room;
        public IModelController ModelController { get; set; }
        public bool HandleInactive { get; set; }

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
                        .Title("Rum")
                        .UseConverter(option => option.ShowRoomMenu())
                        .AddChoices(Enum.GetValues<RoomMenuOptions>())
                    );

                switch (option)
                {
                    case RoomMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case RoomMenuOptions.DisplayRooms:
                        HandleInactive = false;
                        if (DataElementChecker.CheckRoomDataExists(HandleInactive))
                            ModelController.ManageOne(HandleInactive);
                        else
                            ServiceMessager.DataNotFoundMessage();
                        break;
                    case RoomMenuOptions.CreateRoom:
                        ModelController.Create();
                        break;
                    case RoomMenuOptions.DisplayInactive:
                        HandleInactive = true;
                        if (DataElementChecker.CheckRoomDataExists(HandleInactive))
                            ModelController.ManageOne(HandleInactive);
                        else
                            ServiceMessager.DataNotFoundMessage();
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
