using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Enums;
using Hotel.src.MenuManagement.Interfaces;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    public class CleaningMenu : IMenu, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        private static IInstantiable _instance;
        private static readonly object _lock = new object();

        public static IMenu GetInstance(IMenu previousMenu)
        {
            _instance = FactoryManagement.InstanceGenerator.GetInstance<CleaningMenu>(_instance, _lock, previousMenu);

            return (CleaningMenu)_instance;
        }

        public void Run()
        {
            while (true)
            {
                // Sprectre menyval!
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
