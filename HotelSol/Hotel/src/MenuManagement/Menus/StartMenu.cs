using Hotel.src.MenuManagement.Enums;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    public class StartMenu
    {
        public static void Run()
        {
            while (true)
            {
                // Sprectre menyval!
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<MainMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowStartMenu())
                        //.UseConverter(option => option.GetDescription()) // Visa beskrivningar istället för enum-namn
                        .AddChoices(Enum.GetValues<MainMenuOptions>())
                    );

                switch (option)
                {
                    case MainMenuOptions.Login:
                        MainMenu.Run();
                        break;
                    case MainMenuOptions.ViewAllProducts:
                        AdminMenu.Run();
                        break;
                    case MainMenuOptions.Exit:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}