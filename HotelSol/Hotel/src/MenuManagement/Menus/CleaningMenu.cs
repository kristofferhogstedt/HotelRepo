using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using Spectre.Console;

namespace Hotel.src.MenuManagement.Menus
{
    public class CleaningMenu : IMenu, IInstantiable, IControllable, IHandleInactives
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();
        public EModelType ModelType { get; set; } = EModelType.Cleaning;
        public IModelController ModelController { get; set; }
        public bool HandleInactive { get; set; }

        public static IMenu GetInstance(IMenu previousMenu)
        {
            _instance = FactoryManagement.InstanceGenerator.GetInstance<CleaningMenu>(_instance, _lock, previousMenu);

            return (CleaningMenu)_instance;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<CleaningMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowCleaningMenu())
                        .AddChoices(Enum.GetValues<CleaningMenuOptions>())
                    );

                switch (option)
                {
                    case CleaningMenuOptions.PreviousMenu:
                        PreviousMenu.Run();
                        break;
                    case CleaningMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
