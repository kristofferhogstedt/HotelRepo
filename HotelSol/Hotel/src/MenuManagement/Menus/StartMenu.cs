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
                    new SelectionPrompt<StartMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowStartMenu())
                        //.UseConverter(option => option.GetDescription()) // Visa beskrivningar istället för enum-namn
                        .AddChoices(Enum.GetValues<StartMenuOptions>())
                    );

                switch (option)
                {
                    case StartMenuOptions.Login:
                        MainMenu.Run();
                        break;
                    case StartMenuOptions.AdminLogin:
                        Settings.IsAdmin = true;
                        MainMenu.Run();
                        break;
                    case StartMenuOptions.Exit:
                        Exit.ExitProgram();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}