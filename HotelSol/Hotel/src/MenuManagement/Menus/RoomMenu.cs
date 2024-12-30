using Hotel.src.MenuManagement.Enums;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    public class RoomMenu
    {
        public static void Run()
        {
            while (true)
            {
                // Sprectre menyval!
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
                        RoomMenu.Run();
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
