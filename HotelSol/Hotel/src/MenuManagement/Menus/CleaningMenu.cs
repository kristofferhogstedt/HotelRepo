using Hotel.src.MenuManagement.Enums;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    public class CleaningMenu
    {
        public static void Run()
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
                        RoomMenu.Run();
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
