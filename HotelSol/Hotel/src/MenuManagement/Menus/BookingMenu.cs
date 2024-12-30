﻿using Hotel.src.MenuManagement.Enums;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus
{
    internal class BookingMenu
    {
        public static void Run()
        {
            while (true)
            {
                // Sprectre menyval!
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<BookingMenuOptions>()
                        .Title("Start")
                        .UseConverter(option => option.ShowBookingMenu())
                        //.UseConverter(option => option.GetDescription()) // Visa beskrivningar istället för enum-namn
                        .AddChoices(Enum.GetValues<BookingMenuOptions>())
                    );

                switch (option)
                {
                    case BookingMenuOptions.PreviousMenu:
                        MainMenu.Run();
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
