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
    public class MainMenu
    {
        public static void Run()
        {
            while (true)
            {
                // Sprectre menyval!
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<MainMenuOptions>()
                        .Title("Huvudmeny")
                        .UseConverter(option => option.ShowMainMenu())
                        //.UseConverter(option => option.GetDescription()) // Visa beskrivningar istället för enum-namn
                        .AddChoices(Enum.GetValues<MainMenuOptions>())
                    );

                switch (option)
                {
                    case MainMenuOptions.PreviousMenu:
                        StartMenu.Run();
                        break;
                    case MainMenuOptions.ViewAllProducts:
                        ProductController.GetProducts();
                        break;
                    case MainMenuOptions.ViewAllProducts:
                        ProductController.GetProducts();
                        break;
                    case MainMenuOptions.Exit:
                        return;
                    default:
                        break;
                }

                //[Description("Föregående meny")]
                //        PreviousMenu,
                //[Description("Bokningshantering")]
                //        BookingManagement,
                //[Description("Kundhantering")]
                //        CustomerManagement,
                //[Description("Rumhantering")]
                //        RoomManagement,
                //[Description("Admin")]
                //        Admin,
                //[Description("Avsluta")]
            }
        }
    }
}
