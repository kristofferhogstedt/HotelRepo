using Hotel.src.MenuManagement.Enums;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    public class EconomyMenu
    {
        public static void Run()
        {
            while (true)
            {
                // Sprectre menyval!
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<EconomyMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowEconomyMenu())
                        .AddChoices(Enum.GetValues<EconomyMenuOptions>())
                    );

                switch (option)
                {
                    case EconomyMenuOptions.PreviousMenu:
                        MainMenu.Run();
                        break;
                    case EconomyMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
